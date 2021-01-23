	public class NewsDynamicNodeProvider 
		: DynamicNodeProviderBase 
	{ 
		public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node) 
		{
			using (var db = new EnityContext())
			{
				// Create a node for each news article 
				foreach (var news in db.News) 
				{ 
					var dynamicNode = new DynamicNode(); 
					dynamicNode.Title = news.Title;
                    dynamicNode.ParentKey = "News";
					dynamicNode.RouteValues.Add("id", news.Id);
					yield return dynamicNode;
				}
			}
		} 
	}
