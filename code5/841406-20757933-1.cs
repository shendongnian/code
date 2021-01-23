           List<dynamic[]> values = document.DocumentNode.Descendants("select")
               .Select(n =>
                       n.Descendants("select")
                       .Select(x => new
                       {
                           Value = n.Attributes["value"].Value,
                           Text = n.InnerText,
                       }).ToArray()
                   )
            .ToList(); 
