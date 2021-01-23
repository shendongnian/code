    internal static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, string labelText = null, IDictionary<string, object> htmlAttributes = null)
    {
      string str = labelText;
      if (str == null)
      {
        string displayName = metadata.DisplayName;
        if (displayName == null)
        {
          string propertyName = metadata.PropertyName;
          if (propertyName == null)
            str = Enumerable.Last<string>((IEnumerable<string>) htmlFieldName.Split(new char[1]
            {
              '.'
            }));
          else
            str = propertyName;
        }
        else
          str = displayName;
      }
      string innerText = str;
      if (string.IsNullOrEmpty(innerText))
        return MvcHtmlString.Empty;
      TagBuilder tagBuilder1 = new TagBuilder("label");
      tagBuilder1.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
      tagBuilder1.SetInnerText(innerText);
      TagBuilder tagBuilder2 = tagBuilder1;
      bool flag = true;
      IDictionary<string, object> attributes = htmlAttributes;
      int num = flag ? 1 : 0;
      tagBuilder2.MergeAttributes<string, object>(attributes, num != 0);
      return TagBuilderExtensions.ToMvcHtmlString(tagBuilder1, TagRenderMode.Normal);
    }
