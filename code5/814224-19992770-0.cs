	XmlSerializer serializer = new XmlSerializer(typeof(Move));
	
	Move move = new Move { MoveName = "MyName" };
	move.oTags.Add(new Tag { TagName = "Value1" } );
	move.oTags.Add(new Tag { TagName = "Value2" } );
	move.oTags.Add(new Tag { TagName = "Value3" } );
	
	StringBuilder output = new StringBuilder();
	var xmlwriter = XmlWriter.Create(output);
	serializer.Serialize(xmlwriter, move);
	
	Console.WriteLine(output.ToString());
