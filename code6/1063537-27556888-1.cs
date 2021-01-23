    var jQueryBundle = bundles.Add(new ScriptBundle("~/bundles/jquery").AsComposable()
                                .Include("~/Scripts/jquery-{version}.js"));
    bundles.Add(new ScriptBundle("~/bundles/jqueryui").AsComposable()
                    .UseBundle(jQueryBundle)
                    .Include("~/Scripts/jquery-ui-{version}.js"));
