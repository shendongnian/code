    public static MvcHtmlString EditorForMany<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, IEnumerable<TValue>>> expression) where TModel : class
    {
      var items = expression.Compile()(html.ViewData.Model);
      var sb = new StringBuilder();
      var prefix = html.ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix;
      var htmlFieldName = (prefix.Length > 0 ? (prefix + ".") : String.Empty) + ExpressionHelper.GetExpressionText(expression);
      foreach (var item in items)
      {
        var dummy = new { Item = item };
        var guid = Guid.NewGuid().ToString();
        var memberExp = Expression.MakeMemberAccess(Expression.Constant(dummy), dummy.GetType().GetProperty("Item"));
        var singleItemExp = Expression.Lambda<Func<TModel, TValue>>(memberExp, expression.Parameters);
        var editor = html.EditorFor(singleItemExp, null, string.Format("{0}[{1}]", htmlFieldName, guid));
        var hidden = String.Format(@"<input type='hidden' name='{0}.Index' value='{1}' />", htmlFieldName, guid);
        var eNode = HtmlNode.CreateNode(editor.ToHtmlString());
        var hNode = HtmlNode.CreateNode(hidden);
        eNode.AppendChild(hNode);
        sb.Append(eNode.OuterHtml);
      }
      return new MvcHtmlString(sb.ToString());
    }
