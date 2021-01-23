    public override string ToString()
    {
        string content = "", attributes = "";
        foreach (var child in Children)
        {
            content += child;
        }
        if (!string.IsNullOrWhiteSpace(ValueAsString))
        {
            content += ValueAsString;
        }
        foreach (var entry in properties)
        {
            attributes += string.Format(" {0}=\"{1}\"", entry.Key, entry.Value);
        }
        if (string.IsNullOrWhiteSpace(content))
        {
            return string.Format("<{0}{2} />", this.Tag, content, attributes);
        }
        return string.Format("<{0}{2}>{1}</{0}>", this.Tag, content, attributes);
    }
