    List<string> toWrite = new List<string>();
    using (System.IO.StreamReader rd = new System.IO.StreamReader(path))
	{
		string line = null;
		while ((line = rd.ReadLine()) != null)
		{
			if (String.Compare(line, active_user) != 0) //simplified your logic
			{
				toWrite.Add(active_user);
			}
		   
		}
		                                     
	}
    File.WriteAllLines(path, toWrite);
