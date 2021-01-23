	var exampleObject = new Request<class2> 
    {
        Version = "versionExample", 
        Data = new class2 {Property1 = "property1Example"}
    };
	if (args.Count() == 1)
	{
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");
		XmlSerializer serializer = new XmlSerializer(typeof(Request<class2>));
		XmlWriterSettings settings = new XmlWriterSettings();
		settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
		settings.Indent = true;
		settings.OmitXmlDeclaration = true;
		string serializedString = "";
		using (var textWriter = new StringWriter())
		{
			using (var xmlWriter = XmlWriter.Create(textWriter, settings))
			{
				serializer.Serialize(xmlWriter, exampleObject,ns );
			}
			serializedString  = textWriter.ToString();
		}
    }
