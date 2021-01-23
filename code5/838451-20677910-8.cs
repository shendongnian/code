	public class MySiteMapProvider : XmlSiteMapProvider 
	{
		public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
		{
			var lstRoles = (List<tblDetail>)context.Session["sRoles"];
			if (string.IsNullOrWhiteSpace(node.Description))
				return true;
			var formId = Convert.ToInt32(node.Description);
			foreach (var item in lstRoles)
			{
				if (item.FormID == formId)
					return true;
			}
			return false;
		}
	}
