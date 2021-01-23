    public static MvcHtmlString EditorForDynamic<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            where TModel : IAsyncControlWithPrefix
    {
        IAsyncControlWithPrefix model = htmlHelper.ViewData.Model;
        htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix = model.PrefixForPartialRender + htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
        return htmlHelper.EditorFor(expression);
    }
    public static string GetFullText<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
    {
        return htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
    }
