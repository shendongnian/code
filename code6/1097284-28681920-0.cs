    public static class HtmlExtensions
    {
        public static MvcHtmlString TestEditorFor(this HtmlHelper htmlHelper, string expression)
        {
            return new MvcHtmlString("test");
        }
    
        public static MvcHtmlString TestHelperFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression)
        {
            return new MvcHtmlString("test2");
        }
    }
 
     @Html.EditorFor(model => model.name, new { htmlAttributes = new { @class = "form-control" } })
            @Html.TestEditorFor("test") 
            @Html.TestHelperFor(model => model.name) 
            @Html.TestHelperFor(b => b.name)
