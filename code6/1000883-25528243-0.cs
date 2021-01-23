    [RoutePrefix("api/Demo")] // Sets the base route for actions in this controller
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("DemoAction")] // This makes this function map to route http://site/api/Demo/DemoAction
        public IHttpActionResult PerformComplexApiAction(int id)
        {
            ...
