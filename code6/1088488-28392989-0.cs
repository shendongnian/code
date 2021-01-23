    var nodes= htmlDoc.DocumentNode.Descendants()
                        .Where(n => n.Name == "a" || 
    (n.Name == "td" && n.Attribute["width"] != null && n.Attribute["width"].Value != "80" && n.Parent.Name == "tr" && n.Parent.Attribute["class"] != null && n.Parent.Attribute["class"].Value = "Row"));
                        
    
                    foreach (var node in nodes)
                    {
                        if(node.Attribute["href"] != null)
                        {
                             Debug.WriteLine(node.Attribute["href"].Value);
                        }
                        else
                        {
                             Debug.WriteLine(node.InnerText);
                        }
                    }
