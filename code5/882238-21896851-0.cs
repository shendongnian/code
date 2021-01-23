    string[] Lines = File.ReadAllLines(fileName); string[] Fields;
    //Remove Header line
    Lines = Lines.Skip(1).ToArray();
    List<CountTable> emList = new List<CountTable>();
    foreach (var line in Lines)
    {
    	Fields = line.Split(new char[] { ',' });
    	emList.Add(
    		new CountTable
    		{
    			CountID = Fields[0].Replace("\"", ""),
    			Date = Convert.ToDateTime(Fields[1].Replace("\"", "")),
    			UserID = Fields[2].Replace("\"", ""),
    			PrinterID = Fields[3].Replace("\"", ""),
    			Color = Fields[4].Replace("\"", ""),
    			BW = Fields[5].Replace("\"", ""),
    		});
    }
