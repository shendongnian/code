    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    public class HeaderAdderExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Response == null)
                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError, context.Exception);
            context.Response.Content.Headers.Add("header", "value");
        }
    }
