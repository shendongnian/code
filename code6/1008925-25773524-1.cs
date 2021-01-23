	using(StreamReader myReader = new StreamReader(this.myFile))
	{
		string line;
		List<string> list = new List<string>();
		while((line = myReader.ReadLine()) != null)
		{
			list.Add(line);
		}
	}
