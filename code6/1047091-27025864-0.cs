	//////////////////////////////////////////////////////////////////////////////////////////////////
	public static string parseDataFromResponse(string response, string searchToken)
	{
		// look for "searchToken" in the response body and parse its value
		using (XmlReader reader = XmlReader.Create(new StringReader(response))) {
			while (reader.Read()) {
				if((reader.NodeType == XmlNodeType.Element) && (reader.Name == searchToken))
					return reader.ReadString();
			}
		}
		return null;
	}
