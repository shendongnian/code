      protected HtmlHelper htmlHelper;
        protected void Page_Load(object sender, EventArgs e)
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            RouteData routeData = new RouteData();
            routeData.Values["controller"] = "Dummy";
            var controllerContext = new ControllerContext(httpContext, routeData, new DummyController());
            var viewContext = new ViewContext(controllerContext, new WebFormView(controllerContext, "View"), new ViewDataDictionary(), new TempDataDictionary(), TextWriter.Null);
            htmlHelper  = new HtmlHelper(viewContext, new ViewDataBag());                                   
        }
        
        private class ViewDataBag : IViewDataContainer
        {
            ViewDataDictionary viewData = new ViewDataDictionary();
            public ViewDataDictionary ViewData
            {
                get
                {
                    return viewData;
                }
                set
                {
                    viewData = value;
                }
            }
        }
        private class DummyController : Controller
        {
        }
