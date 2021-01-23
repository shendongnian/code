    public class LookupApiController
    {
      [HttpGet]
      public async Task<IHttpActionResult> Index(string someKey)
      {
        //DO something
        return Ok();
      }
    }
