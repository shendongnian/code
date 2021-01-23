    /// <summary>
    /// Enables HTTP Response CacheControl management with ETag values.
    /// </summary>
    public class ClientCacheWithEtagAttribute : ActionFilterAttribute
    {
        private readonly TimeSpan _clientCache;
        private readonly HttpMethod[] _supportedRequestMethods = {
            HttpMethod.Get,
            HttpMethod.Head
        };
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="clientCacheInSeconds">Indicates for how long the client should cache the response. The value is in seconds</param>
        public ClientCacheWithEtagAttribute(int clientCacheInSeconds)
        {
            _clientCache = TimeSpan.FromSeconds(clientCacheInSeconds);
        }
        public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (!_supportedRequestMethods.Contains(actionExecutedContext.Request.Method))
            {
                return;
            }
            if (actionExecutedContext.Response?.Content == null)
            {
                return;
            }
            var body = await actionExecutedContext.Response.Content.ReadAsStringAsync();
            if (body == null)
            {
                return;
            }
            var computedEntityTag = GetETag(Encoding.UTF8.GetBytes(body));
            if (actionExecutedContext.Request.Headers.IfNoneMatch.Any()
                && actionExecutedContext.Request.Headers.IfNoneMatch.First().Tag.Trim('"').Equals(computedEntityTag, StringComparison.InvariantCultureIgnoreCase))
            {
                actionExecutedContext.Response.StatusCode = HttpStatusCode.NotModified;
                actionExecutedContext.Response.Content = null;
            }
            var cacheControlHeader = new CacheControlHeaderValue
            {
                Private = true,
                MaxAge = _clientCache
            };
            actionExecutedContext.Response.Headers.ETag = new EntityTagHeaderValue($"\"{computedEntityTag}\"", false);
            actionExecutedContext.Response.Headers.CacheControl = cacheControlHeader;
        }
        private static string GetETag(byte[] contentBytes)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(contentBytes);
                string hex = BitConverter.ToString(hash);
                return hex.Replace("-", "");
            }
        }
    }
