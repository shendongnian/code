    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //logging request body
            string requestBody = await request.Content.ReadAsStringAsync();
            Trace.WriteLine(requestBody);
            
            //let other handlers process the request
            return await base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                    {
                        //once response is ready, log it
                        var responseBody = task.Result.Content;
                        Trace.WriteLine(responseBody);
                        return task.Result;
                    });
        }
    }
