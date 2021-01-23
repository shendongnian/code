    public static MvcHtmlString ExCheckBox4 (this HtmlHelper helper, string name, bool? value, bool readOnly, string Label, object htmlAttributes)
    {
     var HTML = helper.ExCheckBox(name, value, readOnly, Label, new RouteValueDictionary(htmlAttributes));
     return new MvcHtmlString(HTML.ToString());
    }
