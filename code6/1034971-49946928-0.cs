    public class StringBaseApiController: BaseApiController
    {
     [HttpGet]
     [Route("{id:alpha}")]
     public HttpResponseMessage GetEntity(string id){}
    }
