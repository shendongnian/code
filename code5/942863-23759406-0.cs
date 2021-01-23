    public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
                {
                    HttpControllerDescriptor controllerDescriptor = null;
                    IDictionary<string, HttpControllerDescriptor> controllers = GetControllerMapping();
    
                    IHttpRouteData routeData = request.GetRouteData();
    
                    if (routeData == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
    
                    object apiVersion;
                    if (!routeData.Values.TryGetValue("Version", out apiVersion))
                    {
                        apiVersion = "1";
                    }
    
    
                    object controllerName;
                    if (routeData.Values.TryGetValue("controller", out controllerName))
                    {
                        controllerName = string.Empty;
                    }
                    if (controllerName == null)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
    
                    string newControllerName = String.Concat(controllerName.ToString(), "V", apiVersion);
    
                    if (controllers.TryGetValue(newControllerName, out controllerDescriptor))
                    {
                        return controllerDescriptor;
                    }
                    if (controllers.TryGetValue(controllerName.ToString(), out controllerDescriptor))
                    {
                        return controllerDescriptor;
                    }
                    throw new HttpResponseException(HttpStatusCode.NotFound);
    
                }
