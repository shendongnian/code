    public class BaseController : Controller
    {
        protected string CurrentAction { get; private set; }
        protected string CurrentController { get; private set; }
        
        protected override void Initialize(RequestContext requestContext)
        {
            this.PopulateControllerActionInfo(requestContext);
        }
        
        private void PopulateControllerActionInfo(RequestContext requestContext)
        {
            RouteData routedata = requestContext.RouteData;
            object routes;
             
            if (routedata.Values.TryGetValue("MS_DirectRouteMatches", out routes))
            {
                routedata = (routes as List<RouteData>)?.FirstOrDefault();
            }
            
            if (routedata == null)
                return;
            Func<string, string> getValue = (s) =>
            {
                object o;
                return routedata.Values.TryGetValue(s, out o) ? o.ToString() : String.Empty;
            };
            
            this.CurrentAction = getValue("action");
            this.CurrentController = getValue("controller");
        }
    }
 
