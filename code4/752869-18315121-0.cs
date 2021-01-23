    public static MvcHtmlString InputFile()
            {
                TagBuilder builder = new TagBuilder("input");
                builder.MergeAttribute("type", "file");
                builder.MergeAttribute("name", "image");
              
                return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
            }
