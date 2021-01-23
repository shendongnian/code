		var xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
	<bar>
	<foo>
	</foo>
	<definitions>
		<item address=""123"">AAA</item>
		<item address=""456"">BBB</item>
	</definitions>
	</bar>";
	try
	{
		var document = XDocument.Parse(xml);
		var value = document
						.Descendants("item")
						.Where (e => e.Attribute("address").Value == "123")
						.FirstOrDefault()
						.Value;
		Console.WriteLine(value); 
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
