    public class MyNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(
            TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            // Register the custom exceptions handler.
            pipelines.OnError += (ctx, err) => HandleExceptions(err, ctx); ;
        }
        private static Response HandleExceptions(Exception err, NancyContext ctx)
        {
            var result = new Response();
            result.ReasonPhrase = err.Message;
            if (err is NotImplementedException)
            {
                result.StatusCode = HttpStatusCode.NotImplemented;
            }
            else if (err is UnauthorizedAccessException)
            {
                result.StatusCode = HttpStatusCode.Unauthorized;
            }
            else if (err is ArgumentException)
            {
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                // An unexpected exception occurred!
                result.StatusCode = HttpStatusCode.InternalServerError;    
            }
            return result;
        }
    }
