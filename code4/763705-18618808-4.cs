    public static IHtmlString Tag(this HtmlHelper helper, 
                                  RouteValueDictionary dictionary, 
                                  string tagName)
    {
        var tag = new TagBuilder(tagName);
        tag.MergeAttributes(dictionary);
        return new HtmlString(tag.ToString());
    }
