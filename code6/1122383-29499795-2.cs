    [ODataRoutePrefix("My")]
    public class oMyController : ODataController {
      [HttpGet]
      [ODataRoute()] // <---<< This was the key to proper OData routing
      public IHttpActionResult Get(ODataQueryOptions<FileModel> queryOptions) {
        //Code Here
      }
      [HttpGet]
      [ODataRoute("({mykey})")]
      public IHttpActionResult Get([FromODataUri] String mykey) {
        //Code Here
      }
    }
