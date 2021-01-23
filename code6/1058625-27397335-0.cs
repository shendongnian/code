	var parameters1 = new [] { "a", "b", "c", "d" };
	var parameters2 = new [] { "1", "2", "3" };
	foreach (var par1 in parameters1)
	{
		foreach (var par2 in parameters2)
		{
			string url = string.Format("http://example.com/{0}/{1}", par1, par2);
			Console.WriteLine(url);
		}
	}
