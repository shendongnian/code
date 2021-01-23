    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    namespace CompanyName.Controllers.Api
    {
        [RoutePrefix("services/noop")]
        [AllowAnonymous]
        public class NoOpController : ApiController
        {
            [Route]
            [HttpGet]
            public IHttpActionResult GetNoop()
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateErrorResponse(
                        (HttpStatusCode)422,
                        new HttpError("Something goes wrong")
                    )
                );
            }
        }
    }
