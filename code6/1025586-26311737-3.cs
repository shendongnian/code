       public ActionResult GetPartial()
        {
          var viewStr=RenderPartialToString("~/Views/Home/Partial1.cshtml",new object())
          return content(viewStr);
        }
        // by this method you can  get string of view -- Update
        public string RenderRazorViewToString(string viewName, object model)
            {
                ViewData.Model = model;
                using (var sw = new StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                             viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                                 ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return sw.GetStringBuilder().ToString();
                }
        
