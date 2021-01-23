    using (XmlReader reader = XmlReader.Create(new StringReader(text))) {
	bool skipRead = false;
	while (skipRead || reader.Read()) {
		skipRead = false;
		if (reader.NodeType == XmlNodeType.Element && reader.Name == "Option") {
			string key = reader.GetAttribute("Key");
			string value = reader.ReadInnerXml();
			skipRead = true;
			Console.WriteLine("{0}.{1}", key, value);
		}
	}
