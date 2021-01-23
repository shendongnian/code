     public static IHtmlString HaidarImage(this HtmlHelper instance, string src) 
     {
    
        TagBuilder inst = new TagBuilder("img");
        inst.MergeAttribute("src", src);
        return MvcHtmlString.Create(inst.ToString());   
      }
