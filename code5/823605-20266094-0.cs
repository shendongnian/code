    public abstract AuditableActionController : ApiController
    {
        private readonly ICustomerService customerService;
    
        protected AuditableActionController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
    
        protected ICustomerService CustomerService { get { return this.customerService; } }
    
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            SetUser(cookie["userId"].Value);
    
            // Make sure you call the base method after!
            base.Initialize(controllerContext);
        }
    
        private void SetUser(string userId) { ... }
    }
