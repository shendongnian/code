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
            var path = odataPath.Segments.OfType<EntitySetPathSegment>().SingleOrDefault();
            if (path == null)
            {
                return null;
            }
            return path.EntitySetName + "V4";
        }
    }
