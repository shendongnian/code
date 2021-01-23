	public class MyWeirdController : ApiController {
		//via REST, get object //method-route defined here as I want it
		[HttpGet] [Route("~/my/custom/route/someobject/{objectid}")]	
		public CustomObject GonnaGetCustomObject(int objectid) {
           .... use whatever 
          var obj = new CustomObject();
          obj.SetSomething = true;
         return obj
        }
    }
