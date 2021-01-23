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
        //example implementation of AppliesTo from
        //one of base classes of MVCSiteMapProvider
        //https://github.com/maartenba/MvcSiteMapProvider/blob/master/src/MvcSiteMapProvider/MvcSiteMapProvider/SiteMapNodeVisibilityProviderBase.cs
        public virtual bool AppliesTo(string providerName)
        {
            return this.GetType().ShortAssemblyQualifiedName().Equals(providerName, StringComparison.InvariantCulture);
        }
    }
