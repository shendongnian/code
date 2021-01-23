    List<string> TextLines = new List<string>();
    StringBuilder sb = new StringBuilder();
    foreach (var node in nodes)
    {
        if node class == "related-news"
        {
            // we've found a new "related-news" node.
            // add the previous stuff to the list
            if (sb.Length > 0)
                TextLines.Add(sb.ToString());
            sb = new StringBuilder(node.InnerText);
        }
        else
        {
            sb.Append(node.InnerText);
        }
    }
    // and don't forget the last one
    if (sb.Length > 0)
        TextLines.Add(sb.ToString());
