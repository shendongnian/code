    List<string> lines = new List<string>();
    List<DateTime> dates = new List<DateTime>();
    using (StreamReader sr = new StreamReader(File.OpenRead("Input.txt")))
	{
		while (sr.EndOfStream == false) // read all lines in file until end
		{
			string line = sr.ReadLine();
			if(line == null) continue;
            lines.Add(line); // storing line in collection
 
            // ensuring the line has date, you also may specify date pattern
			DateTime tempDateTime;
			if (DateTime.TryParse(line.Replace(":", ""), out tempDateTime))
			{
				// this line has DateTime
                dates.Add(tempDateTime);
			}
		}
	}
