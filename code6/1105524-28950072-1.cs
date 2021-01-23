    public static IEnumerable<WP> CreateWP(XElement header, IEnumerable<XElement> categories)
	{		
		foreach(XElement category in categories)
		{
			WP wp = new WP();
			wp.GeneralHeader = header.Name.LocalName;
			wp.Category = category.Ancestors().Concat(new []{category}).Where(c=> c.Attributes("name").Any(a=>a.Value == "Category")).Select(elem=>elem.Name.LocalName).FirstOrDefault();
			wp.SubCategory = category.Ancestors().Concat(new []{category}).Where(c=> c.Attributes("name").Any(a=>a.Value == "SubCategory")).Select(elem=>elem.Name.LocalName).FirstOrDefault();
			wp.SubSubCategory = category.Ancestors().Concat(new []{category}).Where(c=> c.Attributes("name").Any(a=>a.Value == "SubSubCategory")).Select(elem=>elem.Name.LocalName).FirstOrDefault();
			
			XmlSerializer xt = new XmlSerializer(typeof(Tool));
			wp.WPTools = category.Descendants("Tool").Select(t=> (Tool) xt.Deserialize(t.CreateReader())).ToList();
			
			XmlSerializer xc = new XmlSerializer(typeof(Contact));
			wp.WPContacts = category.Descendants("Contact").Select(t=> (Contact) xc.Deserialize(t.CreateReader())).ToList();
			yield return wp;
		}
	}
