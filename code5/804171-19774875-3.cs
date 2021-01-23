    public static class HttpRouteUrlExtension {
        private const string HttpRouteKey = "httproute";
        private static readonly Type[] SimpleTypes = new[] {
            typeof (DateTime), 
            typeof (Decimal), 
            typeof (Guid), 
            typeof (string), 
            typeof (TimeSpan)
        };
        public static string HttpRouteUrl( this HttpRequestMessage request, HttpMethod method, object routeValues ) {
            return HttpRouteUrl( request, method, new HttpRouteValueDictionary( routeValues ) );
        }
        public static string HttpRouteUrl( this HttpRequestMessage request, HttpMethod method, IDictionary<string, object> routeValues ) {
            if ( routeValues == null ) {
                throw new ArgumentNullException( "routeValues" );
            }
            if ( !routeValues.ContainsKey( "controller" ) ) {
                throw new ArgumentException( "'controller' key must be provided", "routeValues" );
            }
            routeValues = new HttpRouteValueDictionary( routeValues );
            if ( !routeValues.ContainsKey( HttpRouteKey ) ) {
                routeValues.Add( HttpRouteKey, true );
            }
            string controllerName = routeValues[ "controller" ].ToString();
            routeValues.Remove( "controller" );
            string actionName = string.Empty;
            if ( routeValues.ContainsKey( "action" ) ) {
                actionName = routeValues[ "action" ].ToString();
                routeValues.Remove( "action" );
            }
            IHttpRoute[] matchedRoutes = request.GetConfiguration().Services
                                                .GetApiExplorer().ApiDescriptions
                                                .Where( x => x.ActionDescriptor.ControllerDescriptor.ControllerName.Equals( controllerName, StringComparison.OrdinalIgnoreCase ) )
                                                .Where( x => x.ActionDescriptor.SupportedHttpMethods.Contains( method ) )
                                                .Where( x => string.IsNullOrEmpty( actionName ) || x.ActionDescriptor.ActionName.Equals( actionName, StringComparison.OrdinalIgnoreCase ) )
                                                .Select( x => new {
                                                    route = x.Route,
                                                    matches = x.ActionDescriptor.GetParameters()
                                                               .Count( p => ( !p.IsOptional ) &&
                                                                       ( p.ParameterType.IsPrimitive || SimpleTypes.Contains( p.ParameterType ) ) &&
                                                                       ( routeValues.ContainsKey( p.ParameterName ) ) &&
                                                                       ( routeValues[ p.ParameterName ].GetType() == p.ParameterType ) )
                                                } )
                                                .Where(x => x.matches > 0)
                                                .OrderBy( x => x.route.DataTokens[ "order" ] )
                                                .ThenBy( x => x.route.DataTokens[ "precedence" ] )
                                                .ThenByDescending( x => x.matches )
                                                .Select( x => x.route )
                                                .ToArray();
            if ( matchedRoutes.Length > 0 ) {
                IHttpVirtualPathData pathData = matchedRoutes[ 0 ].GetVirtualPath( request, routeValues );
                if ( pathData != null ) {
                    return new Uri( request.RequestUri, pathData.VirtualPath ).AbsoluteUri;
                }
            }
            return null;
        }
    }
