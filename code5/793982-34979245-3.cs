    public class MySample
    {
        public IHtmlString MyTextBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> propertyExpression,
            CssClass cssClass)
        {
            // ...
        }
    
        public void Usage()
        {
            MyTextBoxFor(html, expression, CssClass.In);
        }
    }
