    public static IHtmlString RenderBundleScript(this HtmlHelper htmlHelper,
                            string bundlePath, object htmlAttributes)
    {
        if (htmlAttributes == null)
        {
            return Scripts.Render(bundlePath);
        }
        else
        {            
            //Create format string for the script tags, including additional html attributes    
            TagBuilder tag = new TagBuilder("script");
            tag.Attributes.Add("src", "{0}");
            tag.Attributes.Add("type", "text/javascript");
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var key in attributes.Keys)
            {
                tag.Attributes.Add(key, attributes[key].ToString());
            }                
            var tagFormat = tag.ToString(TagRenderMode.Normal);
            //render the scripts in the bundle using the custom format
            return Scripts.RenderFormat(tagFormat, bundlePath);
        }
    }
