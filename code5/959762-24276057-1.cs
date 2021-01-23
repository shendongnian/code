    List<TagInfo> tags = new List<TagInfo>();
    while (line != null)
    {
        if (line.Substring(0, 26) == "CRDI-CONTROL %%LINES-BEGIN")
        {
            string tagName = line.Substring(26);
            TagInfo tag = new TagInfo {TagName = tagName};
            tags.Add(tag);
            line = reader.ReadLine();
            while (line.Substring(0, 24) != "CRDI-CONTROL %%LINES-END")
            {
                tag.Data.Add(line.Replace(" ", String.Empty));
                line = reader.ReadLine();
            }
        }
