     // Content css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css")              
                .Include("~/Content/TodoList.css"));
     // Content ej css
            bundles.Add(new StyleBundle("~/Content/ej/web/css")
            .Include("~/Content/ej/web/ej.widgets.core.min.css")
            .Include("~/Content/ej/web/default-theme/ej.theme.min.css"));
     
