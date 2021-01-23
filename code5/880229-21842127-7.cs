        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, String name, List<SelectListItem> listInfo,
            IDictionary<String, Object> htmlAttributes, Int32 columns)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("The argument must have a value", "name");
            if (listInfo == null)
                throw new ArgumentNullException("listInfo");
            if (!listInfo.Any())
                return new MvcHtmlString(String.Empty);
            var outerSb = new StringBuilder();
            for (Int32 i = 0; i < columns; i++)
            {
                var listBuilder = new TagBuilder("ul");
                if (columns > 1)
                    listBuilder.MergeAttribute("class", "column");
                var innerSb = new StringBuilder();
                var take = listInfo.Count % columns == 0
                    ? listInfo.Count / columns
                    : (listInfo.Count / columns) + 1;
                var items = listInfo.Skip(i * take).Take(take);
                foreach (var info in items)
                {
                    var inputBuilder = new TagBuilder("input");
                    if (info.Selected) inputBuilder.MergeAttribute("checked", "checked");
                    inputBuilder.MergeAttribute("type", "checkbox");
                    inputBuilder.MergeAttribute("value", info.Value);
                    inputBuilder.MergeAttribute("id", info.Value);
                    inputBuilder.MergeAttribute("name", info.Value);
                    var labelBuilder = new TagBuilder("label");
                    labelBuilder.MergeAttribute("for", @info.Value);
                    labelBuilder.InnerHtml = info.Text;
                    var listItemWrapper = new TagBuilder("li");
                    //may have to encode here. 
                    listItemWrapper.InnerHtml = inputBuilder.ToString(TagRenderMode.SelfClosing) + labelBuilder.ToString(TagRenderMode.Normal);
                    innerSb.Append(listItemWrapper.ToString(TagRenderMode.Normal));
                }
                listBuilder.InnerHtml = innerSb.ToString();
                outerSb.Append(listBuilder.ToString(TagRenderMode.Normal));
            }
            return new MvcHtmlString(outerSb.ToString());
        }
