        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            HttpControllerDescriptor controllerDescriptor = null;
            // get list of all controllers provided by the default selector
            IDictionary<string, HttpControllerDescriptor> controllers = GetControllerMapping();
            IHttpRouteData routeData = request.GetRouteData();
            if (routeData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //check if this route is actually an attribute route
            IEnumerable<IHttpRouteData> attributeSubRoutes = routeData.GetSubRoutes();
            var apiVersion = GetVersionFromMediaType(request);
            if (attributeSubRoutes == null)
            {
                string controllerName = GetRouteVariable<string>(routeData, "controller");
                if (controllerName == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                string newControllerName = String.Concat(controllerName, "V", apiVersion);
                if (controllers.TryGetValue(newControllerName, out controllerDescriptor))
                {
                    return controllerDescriptor;
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                // we want to find all controller descriptors whose controller type names end with
                // the following suffix(ex: CustomersV1)
                string newControllerNameSuffix = String.Concat("V", apiVersion);
                IEnumerable<IHttpRouteData> filteredSubRoutes = attributeSubRoutes.Where(attrRouteData =>
                {
                    HttpControllerDescriptor currentDescriptor = GetControllerDescriptor(attrRouteData);
                    bool match = currentDescriptor.ControllerName.EndsWith(newControllerNameSuffix);
                    if (match && (controllerDescriptor == null))
                    {
                        controllerDescriptor = currentDescriptor;
                    }
                    return match;
                });
                routeData.Values["MS_SubRoutes"] = filteredSubRoutes.ToArray();
            }
            return controllerDescriptor;
        }
        private HttpControllerDescriptor GetControllerDescriptor(IHttpRouteData routeData)
        {
            return ((HttpActionDescriptor[])routeData.Route.DataTokens["actions"]).First().ControllerDescriptor;
        }
        // Get a value from the route data, if present.
        private static T GetRouteVariable<T>(IHttpRouteData routeData, string name)
        {
            object result = null;
            if (routeData.Values.TryGetValue(name, out result))
            {
                return (T)result;
            }
            return default(T);
        }
