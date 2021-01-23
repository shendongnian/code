    public static class DisplayForExtensions
    {
        public static MvcHtmlString DisplayFor<TModel>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, IFoo>> propertySelector)
        {
            return html.DisplayFor(propertySelector, "IFoo.cshtml");
        }
    }
