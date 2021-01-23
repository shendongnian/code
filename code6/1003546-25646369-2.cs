     private string[] SortFileName(string []TemP)
        {
            var paths = GetTheFileName(TemP);
            List<string> TheCollection = new List<string>();
            
            var result = paths.Select(x => {
		        var match = Regex.Match(x, @"(?<ItemsNumber>\d+)-(?<Revision>\w+)\s+\((?<EndItemNumber>\w+)\).pdf");
		        if (match.Success)
		        {
			        return new { ItemNumber = match.Groups[1].Value, Revision = match.Groups[2].Value, EndItemNumber = match.Groups[3].Value, Path = x };
		        }
		        else {
			        return new { ItemNumber = "", Revision = "", EndItemNumber = "", Path = x };
		        }
	        })
	        .GroupBy(x => x.ItemNumber)
	        .Select(x => x.OrderByDescending(y => y.Revision).First());
           
                foreach (var item in result)
                {
	
                    TheCollection.Add(item.Path.ToString());
                   
                }
        
        return TheCollection.ToArray();
        }
