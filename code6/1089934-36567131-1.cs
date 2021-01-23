    public class RateLimiterHttpModule : IHttpModule
    {
        private readonly IRateLimiter _rateLimiter;
        public RateLimiterHttpModule()
        {
            _rateLimiter = new RateLimiterFactory().CreateRateLimiter();
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }
        private void OnBeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            string ip = application.Context.Request.GetClientIp();
            if (_rateLimiter.ShouldLimit(ip))
            {
                TerminateRequest(application.Context.Response);
            }
        }
        private void TerminateRequest(HttpResponse httpResponse)
        {
            httpResponse.StatusCode = (int)_rateLimiter.LimitStatusCode;
            httpResponse.SuppressContent = true;
            httpResponse.End();
        }
        public void Dispose()
        {
        }
    }
