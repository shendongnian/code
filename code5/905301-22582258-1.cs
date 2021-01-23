	WebClient client = new WebClient();
	client.Credentials = new NetworkCredential("username", "password");
	Byte[] pageData = client.DownloadData(url);
	string pageHtml = Encoding.ASCII.GetString(pageHtml);
	Console.WriteLine(pageHtml);
