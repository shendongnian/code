    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Net;
    
    namespace My.ActionFilters
    {
        /// <summary>
        /// Decorates any MVC route that needs to have client requests limited by time.
        /// </summary>
        /// <remarks>
        /// Uses the current System.Web.Caching.Cache to store each client request to the decorated route.
        /// </remarks>
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        public class ThrottleFilterAttribute : ActionFilterAttribute
        {
            public ThrottleFilterAttribute()
            {
    
            }
            /// <summary>
            /// A unique name for this Throttle.
            /// </summary>
            /// <remarks>
            /// We'll be inserting a Cache record based on this name and client IP, e.g. "Name-192.168.0.1"
            /// </remarks>
            public string Name { get; set; }
    
            /// <summary>
            /// The number of seconds clients must wait before executing this decorated route again.
            /// </summary>
            public int Seconds { get; set; }
    
            /// <summary>
            /// A text message that will be sent to the client upon throttling.  You can include the token {n} to
            /// show this.Seconds in the message, e.g. "Wait {n} seconds before trying again".
            /// </summary>
            public string Message { get; set; }
    
            public override void OnActionExecuting(ActionExecutingContext c)
            {
                 var memCache = (IMemoryCache)c.HttpContext.RequestServices.GetService(typeof(IMemoryCache));
            var testProxy = c.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For");
            var key = 0;
            if (testProxy)
            {
                var ipAddress = IPAddress.TryParse(c.HttpContext.Request.Headers["X-Forwarded-For"], out IPAddress realClient);
                if (ipAddress)
                {
                    key = realClient.GetHashCode(); 
                }
            }
            if (key != 0)
            {
                key = c.HttpContext.Connection.RemoteIpAddress.GetHashCode();
            }
             memCache.TryGetValue(key, out bool forbidExecute);
            memCache.Set(key, true, new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMilliseconds(Milliseconds) });
            
            if (forbidExecute)
            {
                if (String.IsNullOrEmpty(Message))
                    Message = $"You may only perform this action every {Milliseconds}ms.";
                c.Result = new ContentResult { Content = Message, ContentType = "text/plain" };
                // see 409 - http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html
                c.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
            }
        }
        }
    }
