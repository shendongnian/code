	public class MyApiController : ApiController
	{
		public IHttpActionResult AlreadyExists()
		{
			return new System.Web.Http.Results.ResponseMessageResult(
				Request.CreateErrorResponse(
					(HttpStatusCode)409,
					new HttpError("Already exists")
				)
			);
		}
	}
	
	public class RegisterController : MyApiController
	{
		// ...
	}
	
