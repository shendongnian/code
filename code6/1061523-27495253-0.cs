	public void Main()
	{
		var input = new StringReader(Document);
			
		var deserializer = new Deserializer();
			
		var reader = new EventReader(new Parser(input));
			
		// Consume the stream start event "manually"
		reader.Expect<StreamStart>();
			
		// Deserialize the first document
		var firstSet = deserializer.Deserialize<List<string>>(reader);
		
		Console.WriteLine("## First document");
		foreach(var item in firstSet)
		{
			Console.WriteLine(item);
		}
		// Deserialize the second document
		var secondSet = deserializer.Deserialize<List<string>>(reader);
		Console.WriteLine("## Second document");
		foreach(var item in secondSet)
		{
			Console.WriteLine(item);
		}	
	}
