    public class FilterJsonHeaderHandler : DelegatingHandler {
        protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken){
            if (request.Headers.Accept.All(a => a.MediaType == "application/json")){
                // if we have only application/json, so the pipeline continues
                return base.SendAsync(request, cancellationToken);
            }
            // otherwise, do whatever you want:
            var response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            var completionSource = new TaskCompletionSource<HttpResponseMessage>();
            completionSource.SetResult(response);
            return completionSource.Task;
        }
    }
