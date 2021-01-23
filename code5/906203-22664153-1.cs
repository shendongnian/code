    public abstract class BaseApiController : ApiController, IContract
    {
        [Route("Version")]
        [HttpGet]
        public abstract string GetVersion();
    }
