    protected string RenderViewToString(string viewName, object model = null)
    {
      ViewData.Model = model;
      using(StringWriter sw = new StringWriter())
      {
        ViewEngineResult viewResult = ViewEngines.Engines.FindView(ControllerContext, viewName, null);
        ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
        viewResult.View.Render(viewContext, sw);
        return sw.GetStringBuilder().ToString();
      }
    }
    protected string RenderPartialViewToString(string viewName, object model = null)
    {
      ViewData.Model = model;
      using(StringWriter sw = new StringWriter())
      {
        ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
        ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
        viewResult.View.Render(viewContext, sw);
        return sw.GetStringBuilder().ToString();
      }
    }
