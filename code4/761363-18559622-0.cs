    [HttpPost]
    public JsonResult Edit(int id = 0, bool isChecked = false)
    {
        // Your Controller Logic
        return Json((RenderRazorViewToString("PartilaViewName"), JsonRequestBehavior.AllowGet);
    }
        [NonAction]
        public string RenderRazorViewToString(string viewName)
        {
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
