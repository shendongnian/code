    public class CarsController : ApiController
    {
        [Route("cars/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
    
            DoSomething();
    
            return Ok(result);
        }
    
    
    }
