    public static void Main()
	{
		var a = new[] {1, 2, 3};
		var b = new[] {'a', 'b'};
		
		var joined = a.Join(
			b, 
			x => Array.IndexOf(a, x) % b.Length, 
			y => Array.IndexOf(b, y) % a.Length, 
			(x, y) => new object[]{ x, y }
		);
		
		var flat = joined.SelectMany(x => x);
		
		Console.Write(string.Join(", ", flat));
	}
