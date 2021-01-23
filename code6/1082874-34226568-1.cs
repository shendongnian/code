    public class AlbumController : BaseController
    {
        public async Task<IHttpActionResult> Get(int id)
        {
            if (!(await CheckAccessAsync(ChinookResources.AlbumActions.View, 
                                                ChinookResources.Album,
                                                id.ToString())))
            {
                return this.AccessDenied();
            }
    
            return Ok();
        }
    }
