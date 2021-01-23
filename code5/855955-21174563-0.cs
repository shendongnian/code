            public static string RenderViewAsString(string viewName, object model,
            ControllerContext controllerContext, ViewDataDictionary viewData, TempDataDictionary tempData)
        {
            viewData.Model = model;
            using (var stringWriter = new StringWriter())
            {
                var result = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                result.View.Render(
                    new ViewContext(controllerContext, result.View, viewData, tempData, stringWriter),
                    stringWriter);
                return stringWriter.GetStringBuilder().ToString();
            }
        }
