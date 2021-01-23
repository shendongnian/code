    [RoutePrefix("myController")]
    public class MyController : ApiController
    {
        [Route("")]
        public void Post([FromBody]string data)
        {
            leadOptService.AddListOptions(data);            
        }
    }
