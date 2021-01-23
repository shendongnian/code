    namespace YourProject.ControllerExtensions
    {
        using System;
        using System.IO;
        using System.Web.Mvc;
        public static class ControllerExtend
        {
            public static StringReader ViewToString(this Controller controller, string viewName, object model)
            {
                #region MyRegion
                ControllerContext context = controller.ControllerContext;
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                if (model != null)
                {
                    controller.ViewData.Model = model;
                }
                using (var sw = new StringWriter())
                {                
                    var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                    var viewContext = new ViewContext(context, viewResult.View, controller.ViewData, controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(context, viewResult.View);
    
    				
                    //return sw.GetStringBuilder().ToString();
                    return new StringReader(sw.ToString());
    
                }
                #endregion
            }
            
    
        }
    }
