        [RoutePrefix("api/Services")]
        public class ServicesController : ApiController
        {
            [System.Web.Http.AcceptVerbs("GET", "POST")]
            [System.Web.Http.HttpGet]
            [Route("MethodFruit")]
            public string[] MethodFruit()
            {
                return new string[] { "Apple", "Orange", "Banana" };
            }
        }
