    public class HandleExceptionFilter : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
    		var model = new ApiResponseDto() { Success = false, Error = context.Exception.Message })
    		context.Response = context.Request.CreateResponse(HttpStatusCode.OK,
                model);
        }
    }
