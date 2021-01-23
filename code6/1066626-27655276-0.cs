	using (StreamReader sr = new StreamReader(File.OpenRead("Input.txt")))
	{
		while (sr.EndOfStream == false)
		{
			string line = sr.ReadLine();
			if(line == null) continue;
			DateTime tempDateTime;
			if (DateTime.TryParse(line.Replace(":", ""), out tempDateTime))
			{
				// this line has DateTime
			}
		}
	}
