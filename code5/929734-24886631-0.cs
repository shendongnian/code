    Please see below code for CustomLinkRenderer
    
    public class CustomLinkRenderer : LinkRenderer
        {
            public CustomLinkRenderer(Item item)
                : base(item)
            {
    
            }
            public override RenderFieldResult Render()
            {
                string str8;
                SafeDictionary<string> dictionary = new SafeDictionary<string>();
                dictionary.AddRange(this.Parameters);
                if (MainUtil.GetBool(dictionary["endlink"], false))
                {
                    return RenderFieldResult.EndLink;
                }
                Set<string> set = Set<string>.Create(new string[] { "field", "select", "text", "haschildren", "before", "after", "enclosingtag", "fieldname" });
                LinkField linkField = this.LinkField;
                if (linkField != null)
                {
                    dictionary["title"] = StringUtil.GetString(new string[] { dictionary["title"], linkField.Title });
                    dictionary["target"] = StringUtil.GetString(new string[] { dictionary["target"], linkField.Target });
                    dictionary["class"] = StringUtil.GetString(new string[] { dictionary["class"], linkField.Class });
                }
                string str = string.Empty;
                string rawParameters = this.RawParameters;
                if (!string.IsNullOrEmpty(rawParameters) && (rawParameters.IndexOfAny(new char[] { '=', '&' }) < 0))
                {
                    str = rawParameters;
                }
                if (string.IsNullOrEmpty(str))
                {
                    Item targetItem = this.TargetItem;
                    string str3 = (targetItem != null) ? targetItem.DisplayName : string.Empty;
                    string str4 = (linkField != null) ? linkField.Text : string.Empty;
                    str = StringUtil.GetString(new string[] { str, dictionary["text"], str4, str3 });
                }
                string url = this.GetUrl(linkField);
                if (((str8 = this.LinkType) != null) && (str8 == "javascript"))
                {
                    dictionary["href"] = "#";
                    dictionary["onclick"] = StringUtil.GetString(new string[] { dictionary["onclick"], url });
                }
                else
                {
                    dictionary["href"] = HttpUtility.HtmlEncode(StringUtil.GetString(new string[] { dictionary["href"], url }));
                }
                // Add onclick attribute for Google event tracking 
                dictionary["onclick"] = LinkField.GetAttribute("on_click");
                StringBuilder tag = new StringBuilder("<a", 0x2f);
                foreach (KeyValuePair<string, string> pair in dictionary)
                {
                    string key = pair.Key;
                    string str7 = pair.Value;
                    if (!set.Contains(key.ToLowerInvariant()))
                    {
                        FieldRendererBase.AddAttribute(tag, key, str7);
                    }
                }
                tag.Append('>');
                if (!MainUtil.GetBool(dictionary["haschildren"], false))
                {
                    if (string.IsNullOrEmpty(str))
                    {
                        return RenderFieldResult.Empty;
                    }
                    tag.Append(str);
                }
                return new RenderFieldResult { FirstPart = tag.ToString(), LastPart = "</a>" };
            }
        }
