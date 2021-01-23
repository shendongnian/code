    using System.Net;
    using System.Net.Http;
    using System.Web.Http.ExceptionHandling;
    using System.Web.Http.Results;
    public class HeaderAdderExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            HttpResponseMessage response = context.Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError, context.Exception);
            response.Headers.Add("header", "value");
            context.Result = new ResponseMessageResult(response);
        }
    }
