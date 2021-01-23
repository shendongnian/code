    public class AntiForgeryMiddleware
        {
            private readonly RequestDelegate next;
            private readonly string requestTokenCookieName;
            private readonly string[] httpVerbs = new string[] { "GET", "HEAD", "OPTIONS", "TRACE", "POST" };
    
            public AntiForgeryMiddleware(RequestDelegate next, string requestTokenCookieName)
            {
                this.next = next;
                this.requestTokenCookieName = requestTokenCookieName;
            }
    
            public async Task Invoke(HttpContext context, IAntiforgery antiforgery)
            {
    
                string path = context.Request.Path.Value;
      
                if (path != null && path.ToLower().Contains("yourMethodThatGeneratesTheToken"))
                {
                    if (httpVerbs.Contains(context.Request.Method, StringComparer.OrdinalIgnoreCase))
                    {
                        var tokens = antiforgery.GetAndStoreTokens(context);
    
                        context.Response.Cookies.Append(requestTokenCookieName, tokens.RequestToken, new CookieOptions()
                        {
                            HttpOnly = false
                        });
    
    
                    } 
                }
    
                context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
    
                await next.Invoke(context);
            }
        }
