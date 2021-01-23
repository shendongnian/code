    string xml = @"<root>
                    <items>
                     <ITEM id=""1"" name=""bleh"" />
                     <ITEM id=""2"" name=""bleh"" />
                     <ITEM id=""3"" name=""bleh"" />
                     <ITEM id=""4"" name=""bleh"" />
                     <ITEM id=""5"" name=""bleh"" />
                     <ITEM id=""6"" name=""bleh"" />
                     <ITEM id=""7"" name=""bleh"" />
                     <ITEM id=""8"" name=""bleh"" />
                    </items>
                   </root>";
	var doc = new XmlDocument();
	doc.LoadXml(xml);
	foreach (XmlNode node in doc.SelectNodes("//ITEM[@id]"))
	{
		Console.WriteLine(node.Attributes["id"].Value);
	}
