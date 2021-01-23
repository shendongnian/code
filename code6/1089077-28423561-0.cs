    namespace YourAssembly.Html
    {
      public static class MyHelpers
      {
        public static MvcHtmlString BooleanButtonsFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression)
        {
          ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
          string name = ExpressionHelper.GetExpressionText(expression);
          StringBuilder html = new StringBuilder();
          // Yes button
          string id = string.Format("{0}-yes", name);
          html.Append(helper.RadioButtonFor(expression, "True", new { id = id }));
          html.Append(helper.Label(id, "Yes"));
          // Yes button
          id = string.Format("{0}-no", name);
          html.Append(helper.RadioButtonFor(expression, "False", new { id = id }));
          html.Append(helper.Label(id, "No"));
          // enclode in a div for easier styling with css
          TagBuilder div = new TagBuilder("div");
          div.AddCssClass("radiobuttongroup");
          div.InnerHtml = html.ToString();
          return MvcHtmlString.Create(div.ToString());
        }
      }
    }
