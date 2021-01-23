    services.AddTransient<QueryValueService>();
   
----------
    public class QueryValueService
    {
        private readonly HttpContext _context;
    
        public QueryValueService(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor.HttpContext;
        }
    
        public string GetValue()
        {
            return _context.Request.Query["value"];
        }
    }
