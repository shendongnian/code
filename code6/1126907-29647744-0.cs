    public static MvcHtmlString HaidarImage(this HtmlHelper helper, string src)
    {
        TagBuilder tag = new TagBuilder("img");
        tag.Attributes.Add("src", src);
        return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
    }
