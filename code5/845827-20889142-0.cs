    public class BaseApiController : ApiController
    {
        private string ApplicationId
        {
            get
            {
                return HttpContext.Current.Request.Headers["x-application-id"];
            }
        }
    }
