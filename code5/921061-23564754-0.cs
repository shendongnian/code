        // ignore
        routes.Add(new System.Web.Routing.Route("{resource}.axd/{*pathInfo}", new System.Web.Routing.StopRoutingHandler()));
        // sexy static routes
        routes.MapPageRoute("some-page", "some-sexy-url", "~/some/rubbish/path/page.aspx", true);
        // catch all route
        routes.MapPageRoute(
           "All Pages",
           "{*RequestedPage}",
           "~/AssemblerPage.aspx",
           true,
           new System.Web.Routing.RouteValueDictionary { { "RequestedPage", "home" } }
        );
