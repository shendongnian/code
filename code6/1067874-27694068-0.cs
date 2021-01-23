	public void RenderViewToFile(string viewName, object model, string filePath)
	{
		ViewData.Model = model;
		
		using (var sw = new StringWriter())
		{
			var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
			
			var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
			
			viewResult.View.Render(viewContext, sw);
			
			viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
			
			var rendredContent = sw.GetStringBuilder().ToString();
			
			File.WriteAllText(filePath, rendredContent);
		}
	}
