    private static string EditorForManyInternal<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, IEnumerable<TValue>>> expression, IEnumerable<TValue> collection, string templateName)
    {
      var sb = new StringBuilder();
      var prefix = html.ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
      var htmlFieldName = (prefix.Length > 0 ? (prefix + ".") : String.Empty) + ExpressionHelper.GetExpressionText(expression);
      var items = collection ?? expression.Compile()(html.ViewData.Model);
      foreach (var item in items)
      {
        var guid = Guid.NewGuid().ToString();
        var dummy = new { Item = item };
        var memberExp = Expression.MakeMemberAccess(Expression.Constant(dummy), dummy.GetType().GetProperty("Item"));
        var singleItemExp = Expression.Lambda<Func<TModel, TValue>>(memberExp, expression.Parameters);
        var editor = html.EditorFor(singleItemExp, templateName, string.Format("{0}[{1}]", htmlFieldName, guid));
        var hidden = String.Format(@"<input type='hidden' name='{0}.Index' value='{1}' />", htmlFieldName, guid);
        var eNode = HtmlNode.CreateNode(editor.ToHtmlString().Trim());
        if (eNode is HtmlTextNode)
          throw new InvalidOperationException("Unsuported element.");
        if (eNode.GetAttributeValue("id", "") == "")
          eNode.SetAttributeValue("id", guid);
        var hNode = HtmlNode.CreateNode(hidden);
        eNode.AppendChild(hNode);
        sb.Append(eNode.OuterHtml);
      }
      return sb.ToString();
    }
    public static MvcHtmlString EditorForMany<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, IEnumerable<TValue>>> expression, string templateName)
    {
      var value = EditorForManyInternal(html, expression, null, templateName);
      return new MvcHtmlString(value);
    }
