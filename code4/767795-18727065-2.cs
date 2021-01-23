    public class BaseController : Controller
    {
        public MenuModel Menu { get; set; }
        protected override void Initialize(RequestContext requestContext)
        {
            // This get's your menu structure from the database via some service layer you need to create yourself.
            // Keep in mind that this call will happen on every postback so if performance is an issue you might want to cache the menu in some way, maybe per user.
            Menu = _menuServiceLogic.GetMenuItems();
            ViewBag.Menu = Menu;
        }
