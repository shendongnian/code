    var errors = new List<string>();
    var schemaSet = new XmlSchemaSet();
    schemaSet.Add("", XmlReader.Create(new StringReader(Properties.Resources.NameOfXSDResource)));
    document.Validate(schemaSet, (sender, args) =>
    	{
    		errors.Add(args.Message);
    	}
    );
