    public static IHtmlString HaidarImage(this HtmlHelper instance, string src) 
    {
        TagBuilder inst = new TagBuilder("img");
        inst.MergeAttribute("src", src);
        return new HtmlString(inst.ToString(TagRenderMode.SelfClosing));   
    }
