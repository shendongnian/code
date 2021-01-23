    // Using Internal DI
    public class MyImplementation : SiteMapNodeVisibilityProviderBase
    {
        HttpContextBase _context;
        public MyImplementation()
        {
              _context = new HttpContextWrapper(HttpContext.Current);
        }
    
        public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata){
           return !_context.Request.IsAuthenticated;
        }
    }
    // Using External DI
    public class MyImplementation : SiteMapNodeVisibilityProviderBase
    {
        HttpContextBase _context;
        public MyImplementation(HttpContextBase context)
        {
              _context = context;
        }
    
        public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata){
           return !_context.Request.IsAuthenticated;
        }
    }
