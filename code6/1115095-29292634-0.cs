    public static MvcHtmlString HiddenForModel<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
    {
      StringBuilder html = new StringBuilder();
      ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
      var properties = metaData.Properties.Where(p => p.TemplateHint == "HiddenInput");
      foreach(var property in properties)
      {
        html.Append(helper.Hidden(property.PropertyName));
      }
      return MvcHtmlString.Create(html.ToString());
    }
