    bundles.Add(new StyleBundle("~/Content/css")
        .Include("~/Content/Site.css")
        .Include("~/Content/ej/web/ej.widgets.core.min.css",
            new CssRewriteUrlTransform())
        .Include("~/Content/ej/web/default-theme/ej.theme.min.css",
            new CssRewriteUrlTransform())
        .Include("~/Content/TodoList.css"));
