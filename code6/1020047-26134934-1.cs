	public class XmlValue
	{
		public System.Xml.Linq.XElement Element { get; set; }
		public string Text
		{
			get
			{
				if(Element == null) return null;
				return Element.Value;
			}
		}
	}
	public class XmlParser
	{
		public List<XmlValue> GetXml()
		{
			XDocument xdoc = XDocument.Load(@"D:\Web Utf-8 Converter\Categories.xml");
			
			return xdoc
				.Descendants("Categories")
				.SelectMany(p => p.Elements("name"))
				.Select(p => new XmlValue { Element = p });
				.ToList();
		}
	}
	
	void Main()
	{
		XmlParser parser = new XmlParser();
		var list = parser.GetXml();
		foreach(var el in list)
			Console.WriteLine(el.Text);
	}
