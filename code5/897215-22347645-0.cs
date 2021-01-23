        using System.Web.Optimization;
        public class BundleConfig
        {
            public static void RegisterBundles(BundleCollection bundles)
            {
                bundles.Add(new ScriptBundle("~/bundles/js").Include(
                          "~/Scripts/*.js"));
                bundles.Add(new StyleBundle("~/bundles/css").Include(
                           "~/Styles/*.css")); 
            } 
        }
