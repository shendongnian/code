    public class MessageHandler1 : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Process request");
            // Call the inner handler.
            var response = base.SendAsync(request, cancellationToken);
    
            Debug.WriteLine("Process response");
            if (response.Result.StatusCode == HttpStatusCode.NotFound)
            {
                //Create new HttpResponseMessage message
            }
            ;
            return response;
        }
    }
