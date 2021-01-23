	WebClient client = new WebClient();
	client.Credentials = new NetworkCredential("username", "password");
	//Byte[] pageData = client.DownloadData(url);
	//string pageHtml = Encoding.ASCII.GetString(pageHtml);
	// or DownloadString: http://msdn.microsoft.com/en-us/library/fhd1f0sw%28v=vs.110%29.aspx
	var pageHtml = client.DownloadString(uri);
	Console.WriteLine(pageHtml);
