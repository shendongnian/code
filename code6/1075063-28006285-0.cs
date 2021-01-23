    static void stackoverflow_27924923_2752565 (REngine engine)
	{
	    engine.Evaluate ("load('~/f.RData')");
		var s = engine.Evaluate ("f()").AsCharacter()[0];
		Console.WriteLine(s);
	}
