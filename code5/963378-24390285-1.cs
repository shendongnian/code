    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters != null)
            {
                filters.Add(new CustomAuthorizeAttribute());
            }
        }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public sealed class CustomAuthorizeAttribute : AuthorizeAttribute
	{
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
            //your code here
	    }
