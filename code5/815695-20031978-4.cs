	public static class ProjectExtensions
	{
		// retrieve a single element by tag name
		public static XElement GetElementByName(this XDocument xmlDocument, string parentElementName, string elementName)
		{
			var element = xmlDocument.Descendants(parentElementName).Elements().Where (x => x.Name == elementName).FirstOrDefault();
			return element != null ? element : null;
		}
		
		// retrieve attribute by name
		public static string GetAttributeValueByName(this XElement item, string attributeName)
		{
			var attribute = item.Attribute(attributeName);
			return attribute != null ? attribute.Value : string.Empty;
		}
	}
