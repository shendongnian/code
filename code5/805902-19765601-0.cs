    public void SetTextForTag(XmlNode root, TextBox tb, string tag)
    {
        var matches = root.GetElementsByTagName(tag);
        if(matches.Count > 0)
            tb.Text = matches[0].InnerText;
    }
