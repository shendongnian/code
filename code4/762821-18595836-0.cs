    public string RenderPartialViewToString(string viewName, object model, ViewDataDictionary viewData = null)
    {
        ViewData.Model = model;
        if (viewData != null)
            foreach (KeyValuePair<string, object> item in viewData)
                ViewData.Add(item);
        using (var sw = new System.IO.StringWriter())
        {
            var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
            var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
            viewResult.View.Render(viewContext, sw);
            viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
            return sw.GetStringBuilder().ToString();
        }
    }
