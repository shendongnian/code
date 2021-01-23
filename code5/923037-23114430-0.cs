	void Main()
	{
		var letters = new List<string>();
		letters.Add("d.pdf");
		letters.Add("a.pdf");
		letters.Add("c.pdf");
		letters.Add("b.pdf");
		letters.Add("e.pdf");
		
		var results = letters
			.OrderBy(x => x)
			.SkipWhile(x => x != "b.pdf")
			.TakeTo(x => x == "d.pdf")
			.ToList();
		
	}
	
	static class Extensions
	{
		public static IEnumerable<TValue> TakeTo<TValue>(this IEnumerable<TValue> source, Func<TValue, bool> predicate)
		{
			bool predicateReached = false;
			foreach (var value in source)
			{
				yield return value;			
				predicateReached = predicate(value);
				if (predicateReached) yield break;
			}
		}
	}
