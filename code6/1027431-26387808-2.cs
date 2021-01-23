    public class BlogDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            // BlogEntities would be your entity framework context class
            // or repository.
            using (var entities = new BlogEntities())
            {
                // Create a node for each blog post
                foreach (var blogPost in entities.BlogPosts)
                {
                    DynamicNode dynamicNode = new DynamicNode();
                    dynamicNode.Title = blogPost.Title;
                    dynamicNode.ParentKey = "Blog";
                    dynamicNode.Key = "BlogPost_" + blogPost.Id;
                    dynamicNode.RouteValues.Add("id", blogPost.Id);
                    dynamicNode.RouteValues.Add("seoName", blogPost.SeoName);
                    yield return dynamicNode;
                }
            }
        }
    }
