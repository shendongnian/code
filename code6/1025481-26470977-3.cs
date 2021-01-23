    public class CustomVersionedRoute : Attribute, IHttpRouteInfoProvider
    {
        private readonly string _template;
        public CustomVersionedRoute(string route, int version)
        {
            _template = string.Format("v{0}/{1}", version, route);
        }
        public string Name { get { return _template; } }
        public string Template { get { return _template ; } }
        public int Order { get; set; }
    }
    public class CustomersV2Controller : ApiController
    {
        /* Other stuff removed */
        
        [VersionedRoute("Customers", 2)]
        [CustomVersionedRoute("Customers", 2)]
        public IHttpActionResult Get()
        {
            return Json(_customers);
        }
    }
