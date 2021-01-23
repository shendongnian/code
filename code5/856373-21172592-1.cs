    public static MvcHtmlString TextboxForCustom<TModel, TResult>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TResult>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var propName = metadata.PropertyName;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<input type=\"text\" id=\"{0}\" />", propName);
            return MvcHtmlString.Create(sb.ToString());
        }
