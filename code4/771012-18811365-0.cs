    protected void RegistreRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.Ignore("{*allaspx}", new { allaspx = @".*\.aspx(/.*)?" });
        routes.Ignore("{*allcss}", new { allcss = @".*\.css(/.*)?" });
        routes.Ignore("{*alljpg}", new { alljpg = @".*\.jpg(/.*)?" });
        routes.Ignore("{*alljs}", new { alljs = @".*\.js(/.*)?" });
        routes.Add(new System.Web.Routing.Route("{resource}.css/{*pathInfo}", new              
        System.Web.Routing.StopRoutingHandler()));
        routes.Add(new System.Web.Routing.Route("{resource}.js/{*pathInfo}", new 
        System.Web.Routing.StopRoutingHandler()));
        routes.MapPageRoute(
             "HomeRoute",
             "",
             "~/default.aspx"
         );
        routes.MapPageRoute(
        "Lerning-browse", "Learning-CSharp", "~/CSharp.aspx");
    }
    protected void Application_Start(object sender, EventArgs e)
    {
        RegistreRoutes(System.Web.Routing.RouteTable.Routes);
    }
