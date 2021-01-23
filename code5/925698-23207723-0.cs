    public class ImageDenyingModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.BeginRequest += (s, e) => {
                var request = app.Context.Request;
                if (RequiresPageReferrer(request.Url) && !IsValidReferer(request.UrlReferrer)) {
                    app.Context.Response.StatusCode = 404;
                    app.Context.Response.End(); // Or something...
                }
            };
        }
        private bool RequiresPageReferrer(string url) {
        }
        private bool IsValidReferrer(string referrer) {
        }
    }
