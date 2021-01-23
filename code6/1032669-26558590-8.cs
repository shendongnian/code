	public class SomeDynamicNodeProvider : DynamicNodeProviderBase
	{
		public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
		{
            // Get the user name
            var user = node.SiteMap.CacheKey;
			// Entities would be your entity framework context class
			// or repository.
			using (var entities = new Entities())
			{
				// Add the nodes for the current user only
				foreach (var story in entities.Stories.Where(x => x.User == user)
				{
					DynamicNode dynamicNode = new DynamicNode();
					dynamicNode.Title = story.Title;
					
					// The key of the node that this node will be the child of.
					// This works best if you explicitly set the key property/attribute 
					// of the parent node.
					dynamicNode.ParentKey = "Home"; 
					dynamicNode.Key = "Story_" + story.Id;
					dynamicNode.Controller = "Story";
					dynamicNode.Action = "Details";
					// Add the "id" (or any other custom route values)
					dynamicNode.RouteValues.Add("id", story.Id);
					yield return dynamicNode;
                    // If you have child nodes to the current node, you can
                    // nest them here by setting their ParentKey property to 
                    // the same value as the dynamicNode.Key and returning them
                    // using yield return.
				}
			}
		}
	}
