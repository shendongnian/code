    public class ConTypeFilter:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {        
            if ( request.Content.Headers.ContentType==null)
            {
                request.Content.Headers.ContentType=new MediaTypeHeaderValue("application/json");
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
