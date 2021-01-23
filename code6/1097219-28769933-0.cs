      public class HttpFilterModule : IHttpModule
      {
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }
        void context_BeginRequest(object sender, EventArgs e)
        {
            var qs = HttpContext.Current.Request.QueryString["SomeKeyToCheck"];
            var url = HttpContext.Current.Request.Url;
            if (MatchesUrl(url))
            {
                if (!IsAuthenticatedByQueryString(qs))
                {
                    HttpContext.Current.Response.StatusCode = HttpStatusCode.Unauthorized;
                    HttpContext.Current.Response.End();
                }
            }
        }
        private bool IsAuthenticatedByQueryString(string qs)
        {
            //  implement code here to check qs value
            //  probably against a DB or cache of tokens
            return true;
        }
        private bool MatchesUrl(Uri url)
        {
            //  implement code here to match the URL, 
            //  probably against configuration
            return true;
        }
    }
