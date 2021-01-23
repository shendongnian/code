	public List<string> bankload()
	{
		return
		(
			from item in XDocument.Load("newtest.xml").Descendants("BankName")
			select (string)item.Attribute("BankName")
		)
			.Distinct()
			.ToList();
	}
	
	public static List<string> templateload(string bankname)
	{
		return
		(
			from item in XDocument.Load("newtest.xml").Descendants("BankName")
			where item.Attribute("BankName").Value == bankname
			select (string)item.Attribute("TemplateModel")
		)
			.Distinct()
			.ToList();
	}
