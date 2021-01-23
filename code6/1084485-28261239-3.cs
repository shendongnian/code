	public class MembershipService : IMembershipService
	{
		private readonly IHttpContextFactory httpContextFactory;
	
        // This is called at application startup, but note that it 
        // does nothing except get our service(s) ready for runtime.
        // It does not actually use the service.
		public MembershipService(IHttpContextFactory httpContextFactory)
		{
			if (httpContextFactory == null)
				throw new ArgumentNullException("httpContextFactory");
			this.httpContextFactory = httpContextFactory;
		}
		
        // Make sure this is not called from any service constructor
        // that is called at application startup.
		public void DoSomething()
		{
			HttpContextBase httpContext = this.httpContextFactory.Create();
			
			// Do something with HttpContext (at runtime)
		}
	}
