	foreach (var a in q)
	{
		Console.WriteLine(a.ArticleId);
		foreach (var p in a.Photos)
		{
			Console.WriteLine(p);
		}
	}
