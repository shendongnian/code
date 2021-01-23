	public string AddHeaderAndFooter(string rtf)
	{
		// Open file that stores header and footer
		string headerCode = System.IO.File.ReadAllText(Server.MapPath("~/DocTemplates/header.txt"));
		// Inject header and footer code before the last "}" character
		return rtf.Insert(rtf.LastIndexOf('}') - 1, headerCode);
	}
