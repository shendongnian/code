    namespace System.Web.Mvc
    {
        public static class ArrayViewResultExtension
        {
            public static ArrayViewResult ArrayView(this Controller controller, string[] views)
            {
                return ArrayView(controller, views, null);
            }
            public static ArrayViewResult ArrayView(this Controller controller, string[] views, object model)
            {
                if (model != null)
                {
                    controller.ViewData.Model = model;
                }
    
                return new ArrayViewResult
                {
                    ViewName = "",
                    ViewData = controller.ViewData,
                    TempData = controller.TempData,
                    ViewEngineCollection = controller.ViewEngineCollection,
                    Views = views
                };
            }
        }
    }
