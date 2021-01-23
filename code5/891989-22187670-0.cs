    [WebMethod]
	public static IList<string> getAvailableSensors()
	{
		List<string> sensors = new List<string>();
		string path = "C:\\.....\\TestData3.csv";
		string line;
		using (StreamReader sr = new StreamReader(path))
		{
			line = sr.ReadLine();
			sensors = line.Split(',').ToList();
		}
		return sensors;
	}
