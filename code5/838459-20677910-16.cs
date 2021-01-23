	public class MySiteMapProvider : XmlSiteMapProvider 
	{
		public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
		{
			var lstRoles = (List<tblDetail>)context.Session["sRoles"];
           	// when we are accessing ChildNodes, it will execute the same IsAccessibleToUser method for each of this sub nodes
			var childs = node.ChildNodes;
			var isParentNode = node["isParent"] == "true";
			if (childs.Count == 0 && isParentNode)
			{
				// it means that this is node is parent node, and all it sub nodes are not accessible, so we just return false to remove it
				return false;
			}
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
