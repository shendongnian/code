    public class CacheControlAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public int MaxAge { get; set; }
        public CacheControlAttribute()
        {
            MaxAge = 3600;
        }
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            if (context.Response != null)
            {
                context.Response.Headers.CacheControl = new CacheControlHeaderValue
                {
                    Public = true,
                    MaxAge = TimeSpan.FromSeconds(MaxAge)
                };
                context.Response.Headers.ETag = new EntityTagHeaderValue(string.Concat("\"", context.Response.Content.ReadAsStringAsync().Result.GetHashCode(), "\""),true);
            }
            base.OnActionExecuted(context);
        }
    }
