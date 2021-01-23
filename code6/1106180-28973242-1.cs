    services.AddTransient<QueryValueService>();
   
----------
    public class QueryValueService
    {
        private readonly IHttpContextAccessor _accessor;
    
        public QueryValueService(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }
    
        public string GetValue()
        {
            return _accessor.HttpContext.Request.Query["value"];
        }
    }
