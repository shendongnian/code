    [RoutePrefix("acmeapi")]
    [SslClientCertActionFilter] // <== key part!
    public class AcmeProviderController : ApiController
    {
        [HttpGet]
        [Route("{userId}")]
        public async Task<OutputDto> GetInfo(Guid userId)
        {
			// do work ...
        }
    }
