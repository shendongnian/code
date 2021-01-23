        string[] allowedTags = {"SPAN", "DIV", "OL", "LI"};
        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//node()"))
        {
            if (!allowedTags.Contains(node.Name.ToUpper()))
            {
                HtmlNode parent = node.ParentNode;
                parent.RemoveChild(node,true);
            }
        }
