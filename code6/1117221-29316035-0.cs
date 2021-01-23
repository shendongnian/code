            var str = csvString.TrimStart();
            if (str.Split(new string[] { "///" }, StringSplitOptions.None).ToList().Count > 0)
            {
				foreach(var token in str)
				{
					var fields = token.Split(',')
					switch (fields[0])
					{
						case "Cust":
						{
							do something
							
						}
							break;
						case "Something":
						{
							do something
						}
						break;
					}
				}
            }
        
        
