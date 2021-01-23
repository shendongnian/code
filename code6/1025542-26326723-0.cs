	var deserializer = new Deserializer();
	var eventReader = new EventReader(new Parser(new PipeReader(pipe)));
	
	// Consume the initial StreamStart
	eventReader.Expect<StreamStart>();
	
	// Read each document
	do
	{
		var data = deserializer.Deserialize<Dictionary<string, object>>(eventReader);
		Console.WriteLine("{0}\t{1}", DateTime.Now, data["debug"]);
	}
	while(!eventReader.Accept<StreamEnd>());
