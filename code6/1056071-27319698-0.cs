	using System;
	using System.Linq;
	using System.Xml.Linq;
	using System.Xml.XPath;					
	using System.IO;
	public class Program
	{
		public static void Main()
		{
			string xmlFile = AppDomain.CurrentDomain.BaseDirectory + @"Capabilities\" + name + ".xml";
			XElement xml=XElement.Load(xmlFile);
			IEnumerable<XElement> titleElements = xml.XPathSelectElements("//Services/TileMapService/Title");
		}
	}
