    public class CustomNegotiatedContentResult<T> : OkNegotiatedContentResult<T>
    {
        public HttpStatusCode HttpStatusCode;
        public CustomNegotiatedContentResult(
            HttpStatusCode httpStatusCode, T content, ApiController controller)
            : base(content, controller)
        {
            HttpStatusCode = httpStatusCode;
        }
        public override Task<HttpResponseMessage> ExecuteAsync(
            CancellationToken cancellationToken)
        {
            return base.ExecuteAsync(cancellationToken).ContinueWith(
                task => { 
                    // override OK HTTP status code with our own
                    task.Result.StatusCode = HttpStatusCode;
                    return task.Result;
                },
                cancellationToken);
        }
    }
