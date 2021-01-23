           var sb = new StringBuilder();
    doc.LoadHtml(inputHTml);
            
            foreach (var node in doc.DocumentNode.ChildNodes)
        {
            if (node.Name != "img" && node.Name!="a")
            {
                sb.Append(node.InnerHtml);
            }
        }
