    public class RouteConfig
        {
            public enum Culture
            {
                ru = 1,
                en = 2,
                da =3
            }
    
            public class CultureConstraint : IRouteConstraint
            {
                private string[] _values;
                public CultureConstraint(params string[] values)
                {
                    this._values = values;
                }
    
                public bool Match(HttpContextBase httpContext, Route route, string parameterName,
                                    RouteValueDictionary values, RouteDirection routeDirection)
                {
                    string value = values[parameterName].ToString();
                    return _values.Contains(value);
                }
            }
    
            public class MultiCultureMvcRouteHandler : MvcRouteHandler
            {
                protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
                {
                    var culture = requestContext.RouteData.Values["culture"].ToString();
                    var ci = new CultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = ci;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
                    return base.GetHttpHandler(requestContext);
                }
            }
    
            public class SingleCultureMvcRouteHandler : MvcRouteHandler { }
    
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                    );
    
                routes.MapRoute(
                    name: "Order info",
                    url: "orders/{id}",
                    defaults: new { controller = "Order", action = "Index", id = "" });
    
                routes.MapRoute(
                    name: "Shop",
                    url: "shop/{action}/{id}",
                    defaults: new {controller = "Shop", action = "Index", id = UrlParameter.Optional}
                    );
    
                foreach (Route r in routes)
                {
                    if (!(r.RouteHandler is SingleCultureMvcRouteHandler))
                    {
                        r.RouteHandler = new MultiCultureMvcRouteHandler();
                        r.Url = "{culture}/" + r.Url;
    
                        if (r.Defaults == null)
                        {
                            r.Defaults = new RouteValueDictionary();
                        }
                        r.Defaults.Add("culture", Culture.en.ToString());
                        if (r.Constraints == null)
                        {
                            r.Constraints = new RouteValueDictionary();
                        }
                        r.Constraints.Add("culture", new CultureConstraint(Culture.en.ToString(),Culture.da.ToString()));
                    }
                }
    
            }
        }
