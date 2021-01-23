    var xml = "<list><item><id>1</id><param><type>A</type></param></item><item><id>2</id><param><type>A</type></param></item><item><id>3</id><param><type>B</type></param></item><item><id>4</id><param><type>B</type></param></item></list>";
    var document = XDocument.Parse(xml);
    
    foreach ( var param in document.Root.Elements("item").GroupBy(i => i.Element("param").Element("type").Value))
    {
    	var firstId = param.First().Element("id").Value;
    	Console.WriteLine ("The first of {0} = {1}", param.Key, firstId);
    }
