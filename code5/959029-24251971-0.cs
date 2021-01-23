    public class CustomRouteHandler : HttpControllerDispatcher
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Your code here to change the route
    
            return base.SendAsync(request, cancellationToken);
        }
    }
