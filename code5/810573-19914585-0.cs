    public static class InputExtensions
    {
        public static MvcHtmlString TextBoxFor<TModel, TProperty>
            (this HtmlHelper<TModel> htmlHelper, 
             Expression<Func<TModel, TProperty>> expression)
        {
            string format = (string) null;
            return InputExtensions
                    .TextBoxFor<TModel, TProperty>(htmlHelper, expression, format);
        }
    }
