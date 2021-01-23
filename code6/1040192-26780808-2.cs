    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Newtonsoft.Json;
    // based on strathweb implementation
    // http://www.strathweb.com/2012/05/output-caching-in-asp-net-web-api/
    public class CacheHttpGetAttribute : ActionFilterAttribute
    {
        public int Duration { get; set; }
        public ILogExceptions ExceptionLogger { get; set; }
        public IProvideCache CacheProvider { get; set; }
        private bool IsCacheable(HttpRequestMessage request)
        {
            if (Duration < 1)
                throw new InvalidOperationException("Duration must be greater than zero.");
            // only cache for GET requests
            return request.Method == HttpMethod.Get;
        }
        private CacheControlHeaderValue SetClientCache()
        {
            var cachecontrol = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(Duration),
                MustRevalidate = true,
            };
            return cachecontrol;
        }
        private static string GetServerCacheKey(HttpRequestMessage request)
        {
            var acceptHeaders = request.Headers.Accept;
            var acceptHeader = acceptHeaders.Any() ? acceptHeaders.First().ToString() : "*/*";
            return string.Join(":", new[]
            {
                request.RequestUri.AbsoluteUri,
                acceptHeader,
            });
        }
        private static string GetClientCacheKey(string serverCacheKey)
        {
            return string.Join(":", new[]
            {
                serverCacheKey,
                "response-content-type",
            });
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext == null) throw new ArgumentNullException("actionContext");
            var request = actionContext.Request;
            if (!IsCacheable(request)) return;
            try
            {
                // do NOT store cache keys on this attribute because the same instance
                // can be reused for multiple requests
                var serverCacheKey = GetServerCacheKey(request);
                var clientCacheKey = GetClientCacheKey(serverCacheKey);
                if (CacheProvider.Contains(serverCacheKey))
                {
                    var serverValue = CacheProvider.Get(serverCacheKey);
                    var clientValue = CacheProvider.Get(clientCacheKey);
                    if (serverValue == null) return;
                    var contentType = clientValue != null
                        ? JsonConvert.DeserializeObject<MediaTypeHeaderValue>(clientValue.ToString())
                        : new MediaTypeHeaderValue(serverCacheKey.Substring(serverCacheKey.LastIndexOf(':') + 1));
                    actionContext.Response = actionContext.Request.CreateResponse();
                    // do not try to create a string content if the value is binary
                    actionContext.Response.Content = serverValue is byte[]
                        ? new ByteArrayContent((byte[])serverValue)
                        : new StringContent(serverValue.ToString());
                    actionContext.Response.Content.Headers.ContentType = contentType;
                    actionContext.Response.Headers.CacheControl = SetClientCache();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
            }
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                var request = actionExecutedContext.Request;
                // do NOT store cache keys on this attribute because the same instance
                // can be reused for multiple requests
                var serverCacheKey = GetServerCacheKey(request);
                var clientCacheKey = GetClientCacheKey(serverCacheKey);
                if (!CacheProvider.Contains(serverCacheKey))
                {
                    var contentType = actionExecutedContext.Response.Content.Headers.ContentType;
                    object serverValue;
                    if (contentType.MediaType.StartsWith("image/"))
                        serverValue = actionExecutedContext.Response.Content.ReadAsByteArrayAsync().Result;
                    else
                        serverValue = actionExecutedContext.Response.Content.ReadAsStringAsync().Result;
                    var clientValue = JsonConvert.SerializeObject(
                        new
                        {
                            contentType.MediaType,
                            contentType.CharSet,
                        });
                    CacheProvider.Add(serverCacheKey, serverValue, new TimeSpan(0, 0, Duration));
                    CacheProvider.Add(clientCacheKey, clientValue, new TimeSpan(0, 0, Duration));
                }
                if (IsCacheable(actionExecutedContext.Request))
                    actionExecutedContext.ActionContext.Response.Headers.CacheControl = SetClientCache();
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
            }
        }
    }
