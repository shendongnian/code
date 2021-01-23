	public List<string> bankload()
	{
		return
			XDocument
				.Load("newtest.xml")
				.Descendants("BankName")
				.Select(item => (string)item.Attribute("BankName"))
				.Distinct()
				.ToList();
	}
	
	public static List<string> templateload(string bankname)
	{
		return
			XDocument
				.Load("newtest.xml")
				.Descendants("BankName")
				.Where(item => item.Attribute("BankName").Value == bankname)
				.Select(item => (string)item.Attribute("TemplateModel"))
				.Distinct()
				.ToList();
	}
