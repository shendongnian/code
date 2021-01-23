    public static class FlagEnumHelpers
    {
        public static IHtmlString CheckBoxForFlagEnum<T>(this HtmlHelper<T> html, Enum item) 
        {
            TemplateInfo templateInfo = html.ViewData.TemplateInfo;
            string id = templateInfo.GetFullHtmlFieldId(item.ToString());
            string name = templateInfo.GetFullHtmlFieldId(string.Empty);
            var checkbox = new TagBuilder("input");
            checkbox.Attributes["id"] = id;
            checkbox.Attributes["name"] = name;
            checkbox.Attributes["type"] = "checkbox";
            checkbox.Attributes["value"] = item.ToString();
            var model = html.ViewData.Model as Enum;
            if (model != null && model.HasFlag(item))
            {
                checkbox.Attributes["checked"] = "checked";
            }
            return MvcHtmlString.Create(checkbox.ToString());
        }
    }
