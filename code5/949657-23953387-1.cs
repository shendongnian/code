	public static void Main()
	{
		Console.Write("1 -> ");
		foreach(var w in getStringsInsideSlashes("a/b"))
			Console.Write(w + " - ");
		Console.WriteLine("");
		
		Console.Write("2 -> ");
		foreach(var w in getStringsInsideSlashes("a/b/c"))
			Console.Write(w + " - ");
		Console.WriteLine("");
		
		Console.Write("3 -> ");
		foreach(var w in getStringsInsideSlashes("a/b/c/d"))
			Console.Write(w + " - ");
		Console.WriteLine("");
		
		Console.Write("4 -> ");
		foreach(var w in getStringsInsideSlashes("a/b/c/d/"))
			Console.Write(w + " - ");
		Console.WriteLine("");
		
	}
	
	public static string[] getStringsInsideSlashes(string a){
		return a.Split('/').Skip(1).Take(a.Split('/').Count() -2).ToArray<string>();	
	}
