    public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name)
    {
        return TextBox(htmlHelper, name, value: null);
    }
    
    public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name, object value)
    {
        return TextBox(htmlHelper, name, value, format: null);
    }
    
    public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name, object value, string format)
    {
        return TextBox(htmlHelper, name, value, format, htmlAttributes: (object)null);
    }
