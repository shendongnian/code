	public static void AddData(string message)
	{
        string file = Properties.Settings.Default.XMLFileFullName;
		var doc = XDocument.Load(file);
		doc.Root.Add(
			new XElement("Request",
			new XElement("ID", message.Substring(0, 3)),
			new XElement("Message", message))
		);
		doc.Save(file);
	}
