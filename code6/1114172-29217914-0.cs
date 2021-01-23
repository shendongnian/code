	string filename = @"D:\EMS_DATA\firstfile.txt";
	string[] rows = null;
	string[] cols = null;
	string[] lines = File.ReadAllLines(filename)
        .Where(arg => !string.IsNullOrWhiteSpace(arg)).ToArray();
	cols = lines[0].Trim().Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
	int line = 1;
	foreach (string line in lines.Skip(1))
	{
		rows = line.Trim().Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
		for (int counter = 0; counter < cols.Length; counter++)
		{
		    string cellValue = "N/A";
			if(counter < rows.Length)
			    cell = row[counter];
			Console.WriteLine(
                "values at row {0} column {1} are {1} : {2}", 
                line, 
                counter, 
                cols[counter], 
                cellValue);
		}
		
		line++;
	}
	
