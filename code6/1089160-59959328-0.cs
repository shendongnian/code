    using CsvHelper;
    using CsvHelper.Configuration;
    using System.Globalization;
    void Main()
    {
    	using (var writer = new StreamWriter(@"my-file.csv"))
    	{
    		using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    		{
    			csv.Configuration.HasHeaderRecord = false;
    			csv.Configuration.NewLine = NewLine.LF; // <<####################
    
    			var records = new List<Foo>
    			{
    				new Foo { Id = 1, Name = "one" },
    				new Foo { Id = 2, Name = "two" },
    			};
    
    			csv.WriteRecords(records);
    		}
    	}
    }
    
    private class Foo
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
