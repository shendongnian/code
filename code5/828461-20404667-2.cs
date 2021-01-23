     public static MvcHtmlString AddressLink(this HtmlHelper htmlHelper, string address, string status)
    {
        var sb = new StringBuilder();
        sb.Append(htmlHelper.ActionLink(address, status, "Controller"));
        return new MvcHtmlString(sb.ToString());
    }
