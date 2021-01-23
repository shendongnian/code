    public static MvcHtmlString WriteVariables(this HtmlHelper helper, Dictionary<String, Object> values, Boolean writeVar = true) {
        var sb = new StringBuilder("<script type=\"text/javascript\">//<![CDATA[\r\n");
        var seriazlier = new JavaScriptSerializer();
        if (writeVar)
            sb.Append("var ");
        for (var i = 0; i < values.Count; i++) {
            var key = values.Keys.ElementAt(i);
            sb.Append(key).Append("=");
            var currentVal = seriazlier.Serialize(values[key]);
            sb.Append(currentVal).Append(i < values.Count - 1 ? "," : ";");
        }
        sb.Append("//]]></script>");
        return MvcHtmlString.Create(sb.ToString());
    }
