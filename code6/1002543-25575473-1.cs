    public class DefaultController : ApiController
    {
    	[Route, HttpGet]
    	public IHttpActionResult Test()
    	{
    		var json = "{\"name\": \"Dan\",\"children\": [{\"name\": \"Fred\"},{\"name\": \"Fannie\",\"age\": 30,\"children\": {\"own\": [{\"name\": \"Barney\"},{\"name\": \"Angela\"}],\"adopted\": [{\"name\": \"Sven\"}]}}]}";
    
    		var obj = JsonConvert.DeserializeObject(json);
    
    		return Ok(obj);
    	}
    }
