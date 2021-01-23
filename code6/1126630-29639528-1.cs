    public static MvcHtmlString ToMeasure<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string measurement = "sf")
    {
        StringBuilder html = new StringBuilder();
        html.Append(ValueExtensions.ValueFor(helper, expression, "{0:N0}"));
        if (measurement == "m2")
        {
            html.Append("m");
            TagBuilder sup = new TagBuilder("sup");
            sup.InnerHtml = "2";
            html.Append(sup.ToString());
        }
        else
        {
            html.Append(measurement);
        }
        // Optionally you might want to wrap it all in another element?
        TagBuilder span = new TagBuilder("span");
        span.InnerHtml = html.ToString();
        return MvcHtmlString.Create(span.ToString());
    }
