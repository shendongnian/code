    try
	{
		XmlTextWriter view = new XmlTextWriter("C:\\ProgramData\\Microsoft\\Event Viewer\\Views\\View_1.xml", Encoding.Unicode);
		// Root.
		view.WriteStartDocument();
		view.WriteStartElement("ViewerConfig");
		//Create Node for queryConfig
		view.WriteStartElement("QueryConfig");
		view.WriteStartElement("QueryParams");
		view.WriteStartElement("UserQuery");
		view.WriteEndElement();
		view.WriteEndElement();
		//QueryNode
		view.WriteStartElement("QueryNode");
		//....
		
		view.Close();
	}
	catch (XmlException ex)
	{
		Console.WriteLine(ex.StackTrace);
	}
