    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new CustomScriptBundle("~/bundles/Sample").Include(
                    "~/Scripts/a.js",
                    "~/Scripts/b.js",
                    "~/Scripts/c.js"));
    }
