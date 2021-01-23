    foreach(var property in properties)
    {
      TagBuilder input = new TagBuilder("input");
      input.MergeAttribute("type", "hidden");
      input.MergeAttribute("name", property.PropertyName);
      input.MergeAttribute("value", string.Format("{0}", property.Model));
      html.Append(input.ToString());
    }
