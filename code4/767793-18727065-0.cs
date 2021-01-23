    public class BaseController : Controller
    {
        public MenuModel Menu { get; set; }
        protected override void Initialize(RequestContext requestContext)
        {
            // This get's your menu structure from the database via some service layer you need to create yourself.
            Menu = _menuServiceLogic.GetMenuItems();
            ViewBag.Menu = Menu;
        }
