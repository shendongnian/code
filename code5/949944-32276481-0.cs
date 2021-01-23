    public class MyController : ApiController
    {
        //or better yet, dependency-inject this
        SomeService _service = new SomeService();
        public IHttpActionResult Get(int id)
        {
             if (id < 0)
                 return BadRequest("Some error message");
    
             var data = _service.GetData(id);
    
             if (data == null)
                return NotFound();
    
             return Ok(data);
        }
    }
