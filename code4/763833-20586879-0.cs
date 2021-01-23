	void Main()
	{
		var t = new A {FieldOfB = new B {C = 5}};
		
		var serializer = new XmlSerializer(typeof(A));
		
		
		using (var writer = new StringWriter())
		{
			serializer.Serialize(writer, t);
			writer.ToString().Dump();
		}
	}
