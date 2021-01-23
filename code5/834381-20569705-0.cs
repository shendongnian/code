           using (XmlTextReader xmlReader = new XmlTextReader(yourfile))
			{
				XDocument xdoc = XDocument.Load(xmlReader);
				var programs= from programItem in xdoc.Root.Elements()
				              select new xmldata {
					Id  = Convert.ToInt32( programItem.Attribute("Id").Value),
					posx  = Convert.ToInt32(   programItem.Attribute("posx").Value),
					poxy = Convert.ToInt32( programItem.Attribute("poxy").Value),
				};
				result = programs.ToList();
			}
