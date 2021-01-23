    [RoutePrefix("api")]
    public class MyController : ApiController
    {
        [Route("myaction")]
        public IHttpActionResult MyAction()
        {
           //code
        }
        
        [Route("otheraction/{id}")]
        public IHttpActionResult OtherAction(int id)
        {
           //code
        }
    }
