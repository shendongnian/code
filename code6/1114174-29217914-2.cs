	string filename = @"D:\EMS_DATA\firstfile.txt";
	string[] lines = File.ReadAllLines(filename)
        .Where(arg => !string.IsNullOrWhiteSpace(arg)).ToArray();
	string[] cols = lines[0].Trim()
        .Split(new[] {'\t'}, StringSplitOptions.RemoveEmptyEntries);
	int line = 1;
	foreach (string line in lines.Skip(1))
	{
		string[] cells = line.Trim()
            .Split(new[] {'\t'}, StringSplitOptions.RemoveEmptyEntries);
		for (int counter = 0; counter < cols.Length; counter++)
		{
		    string cellValue = "N/A";
			if(counter < cells.Length)
			    cell = cells[counter];
			Console.WriteLine(
                "values at row {0} column {1} are {2} : {3}", 
                line, 
                counter, 
                cols[counter], 
                cellValue);
		}
		
		line++;
	}
	
