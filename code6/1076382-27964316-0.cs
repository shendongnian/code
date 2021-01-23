    public class BaseApiController<TLoginRequest> : ApiController
    where TLoginRequest : LoginRequest
    {
        [Route("login")]
        public virtual HttpResponseMessage Login(TLoginRequest request)
        {
            return new HttpResponseMessage();
        }
    }
