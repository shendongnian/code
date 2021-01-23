    using System.Web;
    using System.Web.Optimization;
    
    namespace MvcApp
    {
        public class BundleConfig
        {
            public static void RegisterBundles(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/bundles/jquery", "https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js").Include("~/Scripts/jquery-{version}.js"));
    
                bundles.Add(new ScriptBundle("~/bundles/bootstrap","https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js").Include("~/Scripts/bootstrap.js","~/Scripts/respond.js"));
    
                bundles.Add(new StyleBundle("~/Content/css", "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css").Include("~/Content/bootstrap.css"));
    
                BundleTable.EnableOptimizations = true;
                bundles.UseCdn = true;
            }
        }
    }
