    using System.Web.Http;
    
    namespace WebApplication2.Controllers
    {
        public class TestController : ApiController
        {
            [HttpPost]
            [Route("api/Departments/PostDepartment/{accountid}/{name}/{dbContext=03}")]
            public string PostDepartment(string accountid, string name, string dbContext)
            {
                return accountid + name + dbContext;
            }
        }
    }
