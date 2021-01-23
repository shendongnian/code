    using System.Web.Optimization;
    
    namespace YourAppNameHere
    {
        public class MvcApplication : System.Web.HttpApplication
        {
            private enum bundleTypes
            {
                Bundle,
                ScriptBundle,
                StyleBundle
            };
    
            void Application_BeginRequest(Object sender, EventArgs e)
            {
                ParseDynamicBundle();
            }
    
            private void ParseDynamicBundle()
            {
                string[] pathParts = Request.FilePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string fileChain = Request.QueryString["files"];
    
                if (pathParts.Length < 2 || fileChain == "")
                    return;
    
                string bundleType = pathParts[0];
    
                if (!Enum.GetNames(typeof(bundleTypes)).Contains(bundleType))
                    return;
    
                string bundleName = pathParts[1];
                string bundleFolder = "";
                Bundle bundle = new Bundle("~/" + bundleType + "/" + bundleName);
    
                if (bundleType == bundleTypes.ScriptBundle.ToString())
                {
                    bundleFolder = "Scripts/";
                    bundle = new ScriptBundle("~/" + bundleType + "/" + bundleName);
                }
                else if (bundleType == bundleTypes.StyleBundle.ToString())
                {
                    bundleFolder = "Styles/";
                    bundle = new StyleBundle("~/" + bundleType + "/" + bundleName);
                }
    
                foreach (string fileName in fileChain.Split(','))
                {
                    bundle.Include("~/" + bundleFolder + fileName);
                }
    
                BundleTable.Bundles.Add(bundle);
            }
        }
    }
