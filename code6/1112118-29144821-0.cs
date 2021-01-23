	public static Dictionary<string, StringBuilder> GetData(DataTable table)
	{
        const string delimiter = "?:";
		var collection = new Dictionary<string, StringBuilder>();
		
		// dotNetFiddle wasn't liking the `.AsEnumerable()` extension
        // But you should still be able to use it here
		foreach (DataRow row in table.Rows)
		{
			var key = (string)row["Name"];
			
			var @value = string.Format("{0},{1},{2}", 
                                       row["Value"], 
                                       row["Type"], 
                                       row["Info"]);
			
			StringBuilder existingSb;
			
			if (collection.TryGetValue(key, out existingSb))
			{
				existingSb.Append(delimiter + @value);
			}
			else
			{
				existingSb = new StringBuilder();
				existingSb.Append(@value);
				collection.Add(key, existingSb);
			}
		}
		return collection;
	}
