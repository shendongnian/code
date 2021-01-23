    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    
    namespace MyApp.Middleware
    {
        public class AlwaysHttpsMiddleware
        {
            private readonly RequestDelegate _next;
    
            public AlwaysHttpsMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context)
            {
                if (context.Request.IsHttps)
                {
                    await _next.Invoke(context);
                }
                else 
                {
                    var request = context.Request;
                    var newUrl = string.Concat(
                        "https://",
                        request.Host.ToUriComponent(),
                        request.PathBase.ToUriComponent(),
                        request.Path.ToUriComponent(),
                        request.QueryString.ToUriComponent());
    
                    context.Response.Redirect(newUrl);
                }
            }
        }
    }
