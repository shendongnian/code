    public class ContentInterceptorHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Content != null)
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                request.Properties["Content"] = requestBody;
                request.Content = new StringContent(requestBody, Encoding.UTF8, request.Content.Headers.ContentType.MediaType);
            }
    
            return await base.SendAsync(request, cancellationToken);
        }
    }
    
    public class LogRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Properties.TryGetValue("Content", out var body))
                return;
            
            Console.WriteLine(body);
        }
    }
