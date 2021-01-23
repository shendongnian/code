    public static string GetFileVirtualPathFromFriendlyUrl(this HttpRequest request) {
            string ret = request.GetFriendlyUrlFileVirtualPath();
            if (ret == string.Empty) {
                for(int j = 0, a = RouteTable.Routes.Count; j<a;j++) {
                    RouteBase r = RouteTable.Routes[j];
                    if (r.GetType() == typeof(Route)) {
                        Route route = (Route)r;
                        StringBuilder newroute = new StringBuilder(route.Url);
                        if (route.Defaults != null && route.Defaults.Count > 1) {
                            string[] keys = route.Defaults.Select(x => x.Key).ToArray();
                            foreach (string k in keys) { 
                                newroute = newroute.Replace("{" + k + "}", k.CheckQueryString()); 
                            }
                        }
                        
                        if (String.Compare(newroute.ToString(), request.Path.Replace(request.ApplicationPath, ""), true) == 0) {
                            if (route.RouteHandler.GetType() == typeof(PageRouteHandler)) {
                                PageRouteHandler handler = (PageRouteHandler)route.RouteHandler;
                                return handler.VirtualPath;
                            }
                        }
                    }
                }
            }
            return ret;
        }
