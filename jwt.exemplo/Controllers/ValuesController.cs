﻿using jwt.exemplo.Authorize;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Jwt.Exemplo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValuesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("v1/compermissao/{value}")]
        [ClaimRequirement("123456789")]
        public string ComPermissao(string value)
        {
            var usuario = _httpContextAccessor.HttpContext.User.FindFirst("UsuarioName").Value;
            return $"Com permissão para o usuário '{usuario}' e valor informado é '{value}'";
        }

        [HttpGet]
        [Route("v1/sempermissao/{value}")]
        [ClaimRequirement("987654321")]
        public string SemPermissao(string value)
        {
            return $"Sem permissão {value}";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
