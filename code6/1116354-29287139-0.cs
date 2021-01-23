    string data = File.ReadAllText(@"C:\temp\csvdata.txt").Replace("\\\"", "\"\"");
    
    //TODO: Use the correct Encoding.
    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
    {
    	using (TextFieldParser csvReader = new TextFieldParser(ms))
    	{
    		csvReader.SetDelimiters(new string[] { "," });
    		csvReader.HasFieldsEnclosedInQuotes = true;
    		string[] colFields = csvReader.ReadFields();
    		foreach (string s in colFields)
    		{
    			Console.WriteLine(s);
    		}
    	}
    }
    
