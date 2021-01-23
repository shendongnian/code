    //Solution #1: If the string (id) has any numeric, it will not be caught.
    //Only alphabets will be caught
    public class StringBaseApiController: BaseApiController
    {
     [HttpGet]
     [Route("{id:alpha}")]
     public HttpResponseMessage GetEntity(string id){}
    }
    //Solution #2: If a seperate route for {id:Int} is already defined, then anything other than Integer will be caught here.
    public class StringBaseApiController: BaseApiController
    {
     [HttpGet]
     [Route("{id}")]
     public HttpResponseMessage GetEntity(string id){}
    }
