    public class NotFoundNegotiatedContentResult<T> : NegotiatedContentResult<T>
    {
        public NotFoundNegotiatedContentResult(T content, ApiController controller)
            : base(HttpStatusCode.NotFound, content, controller)
        {
        }
        public override Task<HttpResponseMessage> ExecuteAsync(
            CancellationToken cancellationToken)
        {
            return base.ExecuteAsync(cancellationToken).ContinueWith(
                task => task.Result, cancellationToken);
        }
    }
