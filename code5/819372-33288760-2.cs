    public class NotFoundNegotiatedContentResult : NegotiatedContentResult<string>
    {
    	public NotFoundNegotiatedContentResult(string content, ApiController controller)
    		: base(HttpStatusCode.NotFound, content, controller) { }
    }
    public class InternalServerErrorNegotiatedContentResult : NegotiatedContentResult<string>
    {
    	public InternalServerErrorNegotiatedContentResult(string content, ApiController controller)
    		: base(HttpStatusCode.InternalServerError, content, controller) { }
    }
