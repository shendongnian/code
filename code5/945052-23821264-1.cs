    public string CreaateXML(List<Room> room)
	{
			var xmlnamespace = new Original.XmlSerializerNamespaces();
			xmlnamespace.Add(string.Empty, string.Empty);
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.OmitXmlDeclaration = omitDeclaration;
			settings.Encoding = encoding;
			XmlWriter writer = XmlWriter.Create(ms, settings);
			XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
			MemoryStream stream = new MemoryStream();
			serializer.Serialize(writer, room, xmlnamespace);
			return Encoding.UTF8.GetString(stream.ToArray());
	}
