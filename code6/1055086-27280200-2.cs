    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using WebAPITest.Models;
    
    namespace WebAPITest.Controllers
    {
        public class ValuesController : ApiController
        {   
            // GET api/values/5
            public async Task<IHttpActionResult> Get(int id, [FromUri] QueryParam queryData)
            {
                return Ok("value");
            }    
        }
    }
