    using (StreamWriter sw = File.CreateText(fileName))
	{
		foreach (FileInfo file in todaysFiles)
		{
			foreach(string line = File.ReadLines(file.FullName));
			{
				if (line.Contains("ERROR"))
				{
					string errLine = "my error";
				
					sw.WriteLine("----- ERROR -----");
					sw.WriteLine(file.Name); //file name
					sw.WriteLine(errLine);  //errline can contain diff nos of lines
					sw.WriteLine("----- ERROR -----");
				}
			}
		 }
	}
