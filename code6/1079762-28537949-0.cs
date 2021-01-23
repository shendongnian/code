    public class WebMvcHelpers
    {
        public static string GetViewPageHtml(object model, string viewName)
        {
            System.Web.Mvc.Controller controller = CreateController<TestController>();
    
            ViewEngineResult result = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
    
            if (result.View == null)
                throw new Exception(string.Format("View Page {0} was not found", viewName));
    
            controller.ViewData.Model = model;
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (System.Web.UI.HtmlTextWriter output = new System.Web.UI.HtmlTextWriter(sw))
                {
                    ViewContext viewContext = new ViewContext(controller.ControllerContext, result.View, controller.ViewData, controller.TempData, output);
                    result.View.Render(viewContext, output);
                }
            }
    
            return sb.ToString();
        }
    
        /// <summary>
        /// Creates an instance of an MVC controller from scratch 
        /// when no existing ControllerContext is present       
        /// </summary>
        /// <typeparam name="T">Type of the controller to create</typeparam>
        /// <returns></returns>
        public static T CreateController<T>(RouteData routeData = null)
                    where T : System.Web.Mvc.Controller, new()
        {
            T controller = new T();
    
            // Create an MVC Controller Context
            HttpContextBase wrapper = null;
            if (HttpContext.Current != null)
                wrapper = new HttpContextWrapper(System.Web.HttpContext.Current);
            //else
            //    wrapper = CreateHttpContextBase(writer);
    
    
            if (routeData == null)
                routeData = new RouteData();
    
            if (!routeData.Values.ContainsKey("controller") && !routeData.Values.ContainsKey("Controller"))
                routeData.Values.Add("controller", controller.GetType().Name
                                                            .ToLower()
                                                            .Replace("controller", ""));
    
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(wrapper, routeData, controller);
            return controller;
        }
    }
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
