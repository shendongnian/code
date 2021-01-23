    public static MvcHtmlString DoubleBoxFor(this HtmlHelper<DoubleNumber> htmlHelper)
    {
        var builder = new StringBuilder();
        builder.AppendLine(htmlHelper.TextBoxFor(g => g.Num1, new { bop = 1 }).ToHtmlString());
        builder.AppendLine(htmlHelper.TextBoxFor(g => g.Num2, new { bop = 1 }).ToHtmlString());
        return null;
    }
