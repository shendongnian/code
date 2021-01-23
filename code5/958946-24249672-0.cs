    [RoutePrefix("{projectName}/usergroups")]
    public class UsergroupController : Controller
    {
        [Route("")]
        public ActionResult Index(string projectName)
        {
            ...
        }
    }
