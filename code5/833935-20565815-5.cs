    namespace MyMVCAppNamespace.MvcHtmlHelpers
    {
        public static class HtmlHelpersExtensions
        {
            public static ResourceManager PartnerResource(this HtmlHelper helper)
            {
                // Get resource filename from viewdata
                string res = helper.ViewContext.ViewData["Resource"].ToString();
                // Load the resource from assembly
                ResourceManager resourceManager = new ResourceManager(res, Assembly.GetExecutingAssembly());
                
                return resourceManager;
            }
        }
    }   
