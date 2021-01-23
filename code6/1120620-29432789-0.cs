	public static void Run()
	{
		string[] jsons = { "[1, 2, 3]", "1" };
		foreach (var json in jsons)
		{
			dynamic d = JsonConvert.DeserializeObject(json);
			if (d is IEnumerable)
			{
				foreach (var i in d)
				{
					Console.WriteLine(i);
				}
			}
			else
			{
				Console.WriteLine(d);
			}
		}
	}
