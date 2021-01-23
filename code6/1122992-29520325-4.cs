    [ProvideContent("Common/Footer")]
    public class ContactDetailsController : Controller
    {
    /*
     * BEGINNING OF REQUIRED CODE BLOCK
     */
        private Task<string> _getContentForLocalPathTask; 
        private string _localPath;
    /*
     * END OF REQUIRED CODE BLOCK
     */
        public async Task<ActionResult> Index()
        {
            //omitted for brevity - awaits some other async methods
    /*
     * BEGINNING OF REQUIRED CODE BLOCK
     */
            string content = await _getContentForLocalPath;
    
            viewResult.ViewBag.SystemContent[_localPath] = new DisplayContentItem(content, _localPath);            
    /*
     * END OF REQUIRED CODE BLOCK
     */
             return View();
        }
    
    public override async void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (filterContext.Result is ViewResult)
        {
            var localPath = filterContext.RouteData.Values["controller"] +
                             "/" + filterContext.RouteData.Values["action"];
    
            if (!_useControllerActionAsPath)
                localPath = _path;
    
            var viewResult = filterContext.Result as ViewResult;
    
    /*
     * BEGINNING OF REQUIRED CODE BLOCK
     */
           _localPath = localPath;
    
           _getContentForLocalPathTask = _contentManager.GetContent(localPath);
    /*
     * END OF REQUIRED CODE BLOCK
     */
            if (viewResult.ViewBag.SystemContent == null)
                viewResult.ViewBag.SystemContent = new Dictionary<string, MvcHtmlString>();
    
        }
    }
