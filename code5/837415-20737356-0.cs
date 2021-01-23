    public class AreaSEOFriendlyRoute : SEOFriendlyRoute, IRouteWithArea
    {
        private readonly string _areaName;
    
        // constructor:
        public AreaSEOFriendlyRoute(string areaName, string url, RouteValueDictionary defaults, IEnumerable<string> valuesToSeo,
            RouteValueDictionary constraints = null, RouteValueDictionary dataTokens = null, IRouteHandler routeHandler = null)
            : base(url, defaults, valuesToSeo, constraints, dataTokens, routeHandler)
        {
            this._areaName = areaName;
        }
    
        // implemented from IRouteWithArea:
        public string Area
        {
            get
            {
                return this._areaName;
            }
        }
    }
