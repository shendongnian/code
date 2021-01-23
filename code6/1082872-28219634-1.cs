    public class AlbumController : ApiController
    {
        protected readonly chinookAuthorization chinookAuth;
        public BaseApiController(chinookAuthorization chinookAuth)
	    {
		    if (chinookAuth == null)
			    throw new ArgumentNullException("chinookAuth");
		    this.chinookAuth = chinookAuth;
	    }
        public async Task<IHttpActionResult> Get(int id)
        {
            if (!(await chinookAuth.CheckAccessAsync((ClaimsPrincipal)RequestContext.Principal, ChinookResources.AlbumActions.View, 
                                            ChinookResources.Album,
                                            id.ToString())))
            {
                return this.AccessDenied();
            }
            return Ok();
        }
    }
