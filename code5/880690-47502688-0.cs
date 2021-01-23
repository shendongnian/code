        public class EmptyController : Controller { }
        public static string RenderRazorViewToString(string viewName, [Optional] object model,[Optional] ViewDataDictionary viewData)
        {
            var controller = ViewRenderer.CreateController<EmptyController>();
            controller.ViewData =viewData??new ViewDataDictionary();
            controller.ViewData.Model = model;
            var context = controller.ControllerContext;
            var html = ViewRenderer.RenderView(viewName, model, context);
            return html;
        }
