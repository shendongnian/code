	public interface IHttpContextFactory
	{
		HttpContextBase Create();
	}
	
	public class HttpContextFactory
        : IHttpContextFactory
    {
        public virtual HttpContextBase Create()
        {
            return new HttpContextWrapper(HttpContext.Current);
        }
    }
	
	public class CurrentUser : ICurrentUser
	{	
		public CurrentUser(IHttpContextFactory httpContextFactory)
		{
			// Using a guard clause ensures that if the DI container fails
			// to provide the dependency you will get an exception
			if (httpContextFactory == null)
				throw new ArgumentNullException("httpContextFactory");
				
			this.httpContextFactory = httpContextFactory;
		}
		// Using a readonly variable ensures the value can only be set in the constructor
		private readonly IHttpContextFactory httpContextFactory;
		private HttpContextBase httpContext = null;
		private Guid userId = null;
		private string UserName = null;
		// Singleton pattern to access HTTP context at the right time
		private HttpContextBase HttpContext
		{
			if (this.httpContext == null)
			{
				this.httpContext = this.httpContextFactory.Create();
			}
			return this.httpContext;
		}
		
		public Guid UserId 
		{ 
			get
			{
				var user = this.HttpContext.User;
				if (this.userId == null && user != null && user.Identity.IsAuthenticated)
				{
					this.userId = user.GetIdentityId().GetValueOrDefault();
				}
				return this.userId;
			}
			set
			{
				this.userId = value;
			}
		}
		
		public string UserName 
		{ 
			get
			{
				var user = this.HttpContext.User;
				if (this.userName == null && user != null && user.Identity.IsAuthenticated)
				{
					this.userName = user.Identity.Name;
				}
				return this.userName;
			}
			set
			{
				this.userName = value;
			} 
		}
	}
