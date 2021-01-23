    public class MyController
    {
        private readonly IMyService _service;
        private readonly HttpContext _httpContext;
        
        public MyController(IMyService service, HttpContext httpContext)
        {
            _service = service;
            _httpContext = httpContext;
        }
        
        public async Task<IHttpActionResult> PostAsync()
        {
            // action method content
        }
    }
