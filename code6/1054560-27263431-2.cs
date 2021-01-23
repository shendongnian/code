    public class ApiLogHandler : DelegatingHandler
    {
     protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,          
                                                   CancellationToken cancellationToken)
     {
       var requestBody = request.Content.ReadAsStringAsync().Result;
       // your logging code here
       return base.SendAsync(request, cancellationToken);
     }
    }
