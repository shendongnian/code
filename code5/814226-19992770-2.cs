	Move move = new Move { MoveName = "MyName" };
	move.oTags.Add(new Tag { TagName = "Value1" } );
	move.oTags.Add(new Tag { TagName = "Value2" } );
	move.oTags.Add(new Tag { TagName = "Value3" } );
	
	StringBuilder output = new StringBuilder();
	var writer = new StringWriter(output);
	
	XmlSerializer serializer = new XmlSerializer(typeof(Move));
	serializer.Serialize(writer, move);
	
	Console.WriteLine(output.ToString());
