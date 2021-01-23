	public static void SendAsync()
	{
		int TaskCount = 8;
		var tasks = Enumerable.Range(0, TaskCount).Select(p => googleit());
		Task.WhenAll(tasks).Wait();
	}
	private static async Task googleit()
	{
		HttpWebRequest request = WebRequest.Create("http://www.google.com") as HttpWebRequest;
		request.Credentials = CredentialCache.DefaultCredentials;
		var response = await request.GetResponseAsync();
		response.Close();
	}
