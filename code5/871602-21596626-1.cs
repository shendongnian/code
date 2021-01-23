	string HtmlResult = String.Empty;
	Console.WriteLine("Starting listing of files....");
	FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Properties.Settings.Default.FtpUrl);
	request.Credentials = new NetworkCredential(Properties.Settings.Default.FtpUsername, Properties.Settings.Default.FtpPassword);
	request.UsePassive = false;
	request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
	FtpWebResponse response = (FtpWebResponse)request.GetResponse();
	using (Stream responsestream = response.GetResponseStream())
	{
		using (StreamReader reader = new StreamReader(responsestream))
		{
			string _line = reader.ReadLine();
			while (_line != null && _line != String.Empty)
			{
				HtmlResult += _line;
				_line = reader.ReadLine();
			}
		}                    
	}
	//parse html output
	HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
	doc.LoadHtml(HtmlResult);
	foreach (HtmlAgilityPack.HtmlNode node in doc.DocumentNode.SelectNodes("//a[@href]"))
	{
		if(node.InnerText.Contains(".txt")) FtpListing.Add(node.InnerText);
	}
	Console.WriteLine("{0} Files found", FtpListing.Count);
