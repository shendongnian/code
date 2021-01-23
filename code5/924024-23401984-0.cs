    public class HttpRequestHelper : IHttpModule
    {
        private const string HttpRequestIsAvailable = "HttpRequestIsAvailable";
    
        public static bool TryGetRequest(HttpContext context, out HttpRequest request)
        {
            request = null;
            if (context != null)
            {
                if (context.Items.Contains(HttpRequestIsAvailable))
                    request = context.Request;
            }
            return (request != null);
        }
        #region IHttpModule
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }
        private void context_BeginRequest(object sender, EventArgs e)
        {
            ((HttpApplication)sender).Context.Items.Add(HttpRequestIsAvailable, true);
        }
        #endregion
    }
