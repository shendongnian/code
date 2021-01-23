    protected string RenderPartialViewToString(ControllerContext context, string viewName, object model)
    {
        if (string.IsNullOrEmpty(viewName))
            viewName = context.RouteData.GetRequiredString("action");
        ViewData.Model = model;
        using (StringWriter sw = new StringWriter())
        {
            ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
            ViewContext viewContext = new ViewContext(context, viewResult.View, ViewData, TempData, sw);
            viewResult.View.Render(viewContext, sw);
            return sw.GetStringBuilder().ToString();
        }
    }
