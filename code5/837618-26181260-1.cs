    public static class CustomExtensions
    {
        public static MvcHtmlString HiddenFor2<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            RemovePropertyState(htmlHelper, expression);
            return htmlHelper.HiddenFor(expression);
        }
        public static MvcHtmlString HiddenFor2<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            RemovePropertyState(htmlHelper, expression);
            return htmlHelper.HiddenFor(expression, htmlAttributes);
        }
        public static MvcHtmlString HiddenFor2<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            RemovePropertyState(htmlHelper, expression);
            return htmlHelper.HiddenFor(expression, htmlAttributes);
        }
        private static void RemovePropertyState<TModel, TProperty>(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            string text = ExpressionHelper.GetExpressionText(expression);
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(text);
            ModelStateDictionary modelState = htmlHelper.ViewContext.ViewData.ModelState;
            if (modelState.ContainsKey(fullName))
            {
                modelState.Remove(fullName);
            }
        }
    }
