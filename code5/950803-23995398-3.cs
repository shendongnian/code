        bundles.Add(new ScriptBundle("~/bundles/jquery")
            .Include("~/Scripts/jquery-{version}.js"));
        bundles.Add(new ScriptBundle("~/bundles/jqueryval")
             .Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
