    public static class HtmlExtensions
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionText, bool canEdit)
        {
            if (canEdit) return html.DropDownListFor(expression, selectList, optionText);
                return html.DropDownListFor(expression, selectList, optionText, new { @disabled = "disabled" });
        }
    }
