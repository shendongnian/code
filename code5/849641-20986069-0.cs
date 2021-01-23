     public class MyServiceHandler : DelegatingHandler
        {
            private readonly MyService _service;
    
            public MyServiceHandler(MyService service)
            {
                _service = service;
            }
    
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Properties["MyService_Key"] = _service;
                return base.SendAsync(request, cancellationToken);
            }
        }
