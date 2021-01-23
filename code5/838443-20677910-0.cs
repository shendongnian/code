    public class MySiteMapProvider : XmlSiteMapProvider 
	{
		public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
		{
            // just sample check
			if (node.Url.StartsWith("/Administration/"))
				return context.User.Identity.Name == "admin";
            return base.IsAccessibleToUser(context, node);
		}
	}
