    class Program
	{
		static void Main(string[] args)
		{
			string fileName = "c:\path\to\file\test.xml";
			var xmlDoc = new XmlDocument();
			xmlDoc.Load(File.OpenRead(fileName));
			XmlNodeList nodeList = xmlDoc.GetElementsByTagName("port");
			XmlNodeReader nodeReader;
			foreach (var node in nodeList)
			{
				using(nodeReader = new XmlNodeReader((XmlNode)node))
				{
					if(nodeReader.ReadToDescendant("script"))
					{
						Console.WriteLine("Found script tag");
					}
				}
			}
			Console.ReadKey();
		}
	}
