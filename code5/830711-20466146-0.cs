        string[] partNumbers = new string[] 
                                { 
                                    "India", "US","UK", "Australia","Germany", "1", "7", "9" 
                                };
								
        var result = partNumbers.OrderBy(x =>
					{
						int i;
						return int.TryParse(x, out i);
					}).ThenBy(x=>x);    
