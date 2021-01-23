	public class UserSiteMapCacheKeyGenerator
		: ISiteMapCacheKeyGenerator
	{
		public virtual string GenerateKey()
		{
			var context = HttpContext.Current;
			if (context.User.Identity.IsAuthenticated)
			{
				// Note: the way you retrieve the user name depends on whether you are using 
				// Windows or Forms authentication
				return context.User.Identity.Name;
			}
			else
			{
				return "default";
			}
		}
	}
