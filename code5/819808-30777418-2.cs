    public class SuppressRedirectHandler : DelegatingHandler
    {
        /// <summary>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                response.Headers.Add("Suppress-Redirect", "True");
                return response;
            }, cancellationToken);
        }
    }
