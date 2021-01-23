    public static class RenderViewHelper
    {
        public static string RenderPartialToString(string viewPath, object model)
        {
            string viewAbsolutePath = MapPath(viewPath);
            var viewSource = File.ReadAllText(viewAbsolutePath);
            string renderedText = Razor.Parse(viewSource, model);
            return renderedText;
        }
        public static string RenderPartialToString(ControllerContext context, string partialViewName, object model)
        {
            ViewEngineResult result = ViewEngines.Engines.FindPartialView(context, partialViewName);
            var viewData = new ViewDataDictionary() { Model = model };
            if (result.View != null)
            {
                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb))
                {
                    using (var output = new HtmlTextWriter(sw))
                    {
                        var viewContext = new ViewContext(context, result.View, viewData, new TempDataDictionary(), output);
                        result.View.Render(viewContext, output);
                    }
                }
                return sb.ToString();
            }
            return string.Empty;
        }
        public static string MapPath(string filePath)
        {
            return HttpContext.Current != null ? HttpContext.Current.Server.MapPath(filePath) : string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, filePath.Replace("~", string.Empty).TrimStart('/'));
        }
    }
