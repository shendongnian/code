                                                                      V----- specific type ----------------V
    public static MvcHtmlString CreateControl<TValue>(this HtmlHelper<MyModel> htmlHelper, Expression<Func<MyModel, TValue>> expression, IEnumerable<SelectListItem> items, object htmlAttributes = null)
    {
      var name = ExpressionHelper.GetExpressionText(expression);
      var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
      var model = htmlHelper.ViewData.Model;
      ...
    
      int i = 0;
      i = i + 1;
    }
