    public class EnableETag : ActionFilterAttribute
    {
        /// <summary>
        /// NOTE: a real production situation, especially when it involves a web garden
        ///       or a web farm deployment, the tags must be retrieved from the database or some other place common to all servers.
        /// </summary>
        private static ConcurrentDictionary<string, EntityTagHeaderValue> etags = new ConcurrentDictionary<string, EntityTagHeaderValue>();
        public override void OnActionExecuting(HttpActionContext context)
        {
            var request = context.Request;
            if (request.Method == HttpMethod.Get)
            {
                var key = GetKey(request);
                ICollection<EntityTagHeaderValue> etagsFromClient = request.Headers.IfNoneMatch;
                if (etagsFromClient.Count > 0)
                {
                    EntityTagHeaderValue etag = null;
                    if (etags.TryGetValue(key, out etag) && etagsFromClient.Any(t => t.Tag == etag.Tag))
                    {
                        context.Response = new HttpResponseMessage(HttpStatusCode.NotModified);
                        SetCacheControl(context.Response);
                    }
                }
            }
        }
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            var request = context.Request;
            var key = GetKey(request);
            EntityTagHeaderValue etag;
            if (!etags.TryGetValue(key, out etag) || request.Method == HttpMethod.Put ||
            request.Method == HttpMethod.Post)
            {
                etag = new EntityTagHeaderValue("\"" + Guid.NewGuid().ToString() + "\"");
                etags.AddOrUpdate(key, etag, (k, val) => etag);
            }
            context.Response.Headers.ETag = etag;
            SetCacheControl(context.Response);
        }
        private string GetKey(HttpRequestMessage request)
        {
            return request.RequestUri.ToString();
        }
        /// <summary>
        /// Defines the time period to hold item in cache (currently 10 seconds)
        /// </summary>
        /// <param name="response"></param>
        private void SetCacheControl(HttpResponseMessage response)
        {
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromSeconds(10),
                MustRevalidate = true,
                Private = true
            };
        }
    }
}
       
