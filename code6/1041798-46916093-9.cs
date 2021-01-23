    private string ConvertViewToString(string viewName, object model)
    {
      ViewData.Model = model;
      using (StringWriter writer = new StringWriter())
      {
        ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
        ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
        vResult.View.Render(vContext, writer);
        return writer.ToString();
      }
    }
