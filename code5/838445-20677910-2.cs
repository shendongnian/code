    public class MySiteMapProvider : XmlSiteMapProvider 
	{
		public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
        {
            // just sample check
			if (node.Url.StartsWith("/Administration/"))
				return context.User.Identity.Name == "admin";
            // or you can query your db
            using(var dbContext = new SomeContext())
            {
            	var userName = context.User.Identity.Name;
            	var currentUser = dbContext.Users.First(u => u.AccountName == userName);
            	if (node.Url.StartsWith("/Administration/") && currentUser.Permission.IsAllowdAdminsPage)
            		return true;
            	// others checks
            }
            // or you can access your current page and get data from it
			var currentPage = context.Handler as Page;
			if (currentPage != null)
			{
				var someControl = currentPage.FindControl("someControl");
				// some custom checks
			}
            return base.IsAccessibleToUser(context, node);
		}
	}
