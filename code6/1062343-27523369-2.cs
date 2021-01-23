	[XmlRootAttribute("ls")]
	public class Request<T>
	{
		[XmlAttribute("ver")]
		public string Version { get; set; }
		[XmlElement(ElementName = "ChildClass")]
		public T Data { get; set; }
	}
	[XmlRoot("ChildClass")]
	public class class2
	{
		[XmlElement("login")]
		public string Property1 { get; set; }
	}
	var exampleObject = new Request<class2> 
    {
        Version = "versionExample", 
        Data = new class2 {Property1 = "property1Example"}
    };
	if (args.Count() == 1)
	{
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
				serializer.Serialize(xmlWriter, exampleObject );
			}
			serializedString  = textWriter.ToString();
		}
    }
