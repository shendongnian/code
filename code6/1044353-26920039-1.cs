    private static void TestXmlBars()
		{
				string s = @"<root>
											<Bars1>...</Bars1>
											<Bars2>...</Bars2>
											<Gubbins3>...</Gubbins3>
										</root>";
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(s);
				List<int> exclude = new List<int>{1,2};
                // create comma-delimited list
				string list = "," + exclude.ToStringElements() + ","; 
				string xpath = String.Format("/root/*/Bar[contains('{0}', concat(',', @name, ','))]", list);
				XmlNodeList nodesToExclude = doc.SelectNodes(xpath);
				foreach (XmlNode node in nodesToExclude)
				{
						node.ParentNode.RemoveChild(node);
				}
				Console.WriteLine(doc.OuterXml);
		}
