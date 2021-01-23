    //Create the object of particular router
    var rr = new System.Web.Routing.Route(tblcmspage.PageUrlName, new MvcRouteHandler())
                {
                    Defaults = new System.Web.Routing.RouteValueDictionary(new { controller = "MyPages", action = "en" }),
                    DataTokens = new System.Web.Routing.RouteValueDictionary(new { namespaces = new[] { "MGP_RealState.Controllers" } })
                };
    //delete the router                
    System.Web.Routing.RouteTable.Routes.Remove(rr);
