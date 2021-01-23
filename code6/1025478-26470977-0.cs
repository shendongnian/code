    [RoutePrefix("api")]
    public class CustomersV1Controller : ApiController
    {
        /* Other stuff removed */
        
        [VersionedRoute("Customers", 1)]
        [Route("v1/Customers")]
        public IHttpActionResult Get()
        {
            return Json(_customers);
        }
    }
