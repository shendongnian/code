	public static void Run()
	{
		string[] jsons = { "[1, 2, 3]", "1" };
		foreach (var json in jsons)
		{
			
			List<int> myInts;
			dynamic d = JsonConvert.DeserializeObject(json);
			if (d is IEnumerable)
			{
				myInts = JsonConvert.DeserializeObject<List<int>>(json);
			}
			else
			{
				myInts = new List<int> {JsonConvert.DeserializeObject<int>(json)};
			}
			foreach (var myInt in myInts)
			{
				Console.Write(myInt);
			}
			Console.WriteLine();
		}
	}
