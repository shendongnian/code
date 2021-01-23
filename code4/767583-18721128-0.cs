    public class MyImplementation:ISiteMapNodeVisibilityProvider
    {
        HttpContext _context;
        public MyImplementation(HttpContext context)
        {
              _context = context;
        }
       
        bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata){
           return !_context.Request.IsAuthenticated;
        }
    }
