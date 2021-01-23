    public class VideoController : ApiController
    {
        [HttpGet]
        [Route("activevideos")]
        public IList<Video> GetActiveVideos(ODataQueryOptions<Video> options)
        {
            var s = new ODataQuerySettings() { PageSize = 1 };
            var result = options.ApplyTo(
                new GetvContext().Videos.Where(c => c.IsActive), s)
                .ToList();
            return result;
        }        
    }
