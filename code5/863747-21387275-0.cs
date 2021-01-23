    private void savefile(string encrypted, string name)
    {
    	using(CsvFile file = new CsvFile())
    	{
    		using(CsvRecord rec = new CsvRecord())
    		{
    			using(CsvWriter write = new CsvWriter())
    			{
    
    				rec.Fields.Add(name);
    				rec.Fields.Add(encrypted);
    
    				file.Records.Add(rec);
    				write.AppendCsv(file, "data.csv");
    			}
    		}
    	}
    }
