    public class MonitoringDelegate : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var watcher = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);
            watcher.Stop();
    
            //store duration somewheren here in the response header
            response.Headers.Add("X-Duration", watcher.ElapsedMilliseconds.ToString());
    
            return response;
        }
    }
