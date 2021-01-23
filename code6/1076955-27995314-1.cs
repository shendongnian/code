    namespace YourAssembly.Html
    {
      public static class EnumHelpers
      {
        public static MvcHtmlString EnumRadioButtonListFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
          ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
          string name = ExpressionHelper.GetExpressionText(expression);
          if (!metaData.ModelType.IsEnum)
          {
            throw new ArgumentException(string.Format("The property {0} is not an enum", name));
          }
          string[] names = Enum.GetNames(metaData.ModelType);
          StringBuilder html = new StringBuilder();
          foreach(string value in names)
          {
            string id = string.Format("{0}_{1}", name, value);
            html.Append("<div>");
            html.Append(helper.RadioButtonFor(expression, value, new { id = id }));
            html.Append(helper.Label(id, value));
            html.Append("</div>");
          }
          return MvcHtmlString.Create(html.ToString());
        }
      }
    }
