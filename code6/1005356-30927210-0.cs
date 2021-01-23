    public class CustomControllerRoutingConvention : IODataRoutingConvention
    {
        public string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
        {
            return null;
        }
        public string SelectController(ODataPath odataPath, HttpRequestMessage request)
        {
            if (odataPath.EdmType == null)
                return null;
            return odataPath.NavigationSource.Name + "V4";
        }
    }
