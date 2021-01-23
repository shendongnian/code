    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new ScriptBundle("~/bundles/base/js").Include("~/Scripts/Site.js"));
        bundles.Add(new StyleBundle("~/bundles/base/css").Include("~/Content/Site.css"));
    }
