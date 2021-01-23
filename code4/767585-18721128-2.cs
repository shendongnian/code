    public class MyImplementation:ISiteMapNodeVisibilityProvider
    {
        HttpContext _context;
        public MyImplementation(HttpContext context)
        {
              _context = context;
        }
       
        public bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata){
           return !_context.Request.IsAuthenticated;
        }
        public bool AppliesTo(string providerName){
            //some code here which return boolean
        }
    }
