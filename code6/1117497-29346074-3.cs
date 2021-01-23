    protected string RenderView(PartialViewResult result)
    {
      using (var sw = new StringWriter())
      {
        result.View = ViewEngines.Engines.FindPartialView(ControllerContext, result.ViewName).View;
        ViewContext vc = new ViewContext(ControllerContext, result.View, result.ViewData, result.TempData, sw);
        result.View.Render(vc, sw);
        return sw.GetStringBuilder().ToString();
      }
    }
    protected ContentResult EditorForMany<TModel, TProperty>(PartialViewResult singleItem, Expression<Func<TModel, TProperty>> expression)
    {
      var prefix = ViewData.TemplateInfo.HtmlFieldPrefix;
      var htmlFieldName = prefix.Length > 0 ? prefix + '.' : "";
      htmlFieldName += ExpressionHelper.GetExpressionText(expression);
      var sb = new StringBuilder();
      var guid = Guid.NewGuid().ToString();
      ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("{0}[{1}]", htmlFieldName, guid);
      var editor = RenderView(singleItem);
      var hidden = String.Format(@"<input type='hidden' name='{0}.Index' value='{1}' />", htmlFieldName, guid);
      var eNode = HtmlNode.CreateNode(editor);
      var hNode = HtmlNode.CreateNode(hidden);
      eNode.AppendChild(hNode);
      return Content(eNode.OuterHtml);
    }
