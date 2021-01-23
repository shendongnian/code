    /// <summary>
    /// 
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="filename"></param>
    /// <param name="path">if null/empty will use IO.Path.GetTempPath()</param>
    /// <param name="extension">will use csv by default</param>
    public static void ToCsv(this IDataReader reader, string filename, string path = null, string extension = "csv")
    {
    	int nextResult = 0;
    	do
    	{
    		var filePath = Path.Combine(string.IsNullOrEmpty(path) ? Path.GetTempPath() : path, string.Format("{0}.{1}", filename, extension));
    		using (StreamWriter writer = new StreamWriter(filePath))
    		{
    			writer.WriteLine(string.Join(",", Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList()));
    			int count = 0;
    			while (reader.Read())
    			{
    				writer.WriteLine(string.Join(",", Enumerable.Range(0, reader.FieldCount).Select(reader.GetValue).ToList()));
    				if (++count % 100 == 0)
    				{
    					writer.Flush();
    				}
    			}
    		}
    
    		filename = string.Format("{0}-{1}", filename, ++nextResult);
    	}
    	while (reader.NextResult());
    }
