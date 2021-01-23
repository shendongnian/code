    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    VirtualPathUtility.ToAppRelative(Links.Scripts.jquery_2_1_1_min_js),
                    VirtualPathUtility.ToAppRelative(Links.Scripts.jquery_migrate_1_2_1_min_js),
                    VirtualPathUtility.ToAppRelative(Links.Scripts.calendar.jquery_ui_datepicker_cc_all_min_js)
                    ));
    }
