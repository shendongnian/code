    foreach (XElement el in xDoc.Root.Elements())
		{
			if(el.Attribute("type").Value == choice)
			{
                XElement elStr = el.Element("strings");                
                foreach (XElement elText in elStr.Elements("text"))
                {
                    textStrings.Add((string)elText);
                }      
                break;
			}
		}
