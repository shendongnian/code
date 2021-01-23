    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
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
                
                // only redirect for GET requests, otherwise the browser might
                // not propagate the verb and request body correctly.
                   
                if (!string.Equals(request.Method, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("This site requires HTTPS.");
                }
                else
                {
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
