     public string[] GetTop10Tags(DynamicNodeList pages)
        {
            List<string> tags = new List<string>();
    
            foreach (DynamicNode node in pages)
            {
                if (node.GetPropertyValue("postTags") != null)
                {
                    string[] aTags = node.GetPropertyValue("postTags").Split(',');
    
                    foreach (string tag in aTags)
                    {
                        tags.Add(tag);
                    }
                }
            }
    
            string[] orderedList = tags
                .GroupBy(i => i)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key).Take(10).ToArray();
    
            return orderedList;
        }
