    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.IgnoreList.Clear();
        bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Views/Shared/Js/jquery-{version}.js",
            "~/Views/Shared/Js/jquery.color-{version}.js")
        );
    }
