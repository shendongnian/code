    var reports = xml.Descendants("Report").Select(reportElement => new
    {
        Name = reportElement.Attribute("Name").Value,
        Parameters = reportElement.Descendants("ParameterList").Select(parameter => 
        {
            List<string> names = parameter.Elements("Name").Select(x=>x.Value).ToList();
            List<string> values = parameter.Elements("Value").Select(x=>x.Value).ToList();
            List<object>  pairs=new List<object>();
            for (int i = 0; i < names.Count; i++)
            {
                pairs.Add(new { Name = names[i], Value = values[i] });
            }
            return pairs;                    
        }).ToList()
    }).ToList();
