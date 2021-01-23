	private static readonly WebHeaderCollection Headers = new WebHeaderCollection()
		{
			{"Authorization", "Basic asdadsasdas8586"},
			{"command", "requestnewpassword"},
			{"application", "netconnect"}
		};
	private static void Start(int nRequests)
	{
		WebRequest.DefaultWebProxy = null;
		for (var i = 0; i < nRequests; ++i) {
			SendRequest();
		}
	}
	private static bool SendRequest()
	{
		var request = HttpWebRequest.Create("URL");
		request.Headers = Headers;
		//Set other properties (like .Method) here
		using (var response = (HttpWebResponse)request.GetResponse()) {
			//Returns boolean indicating success
			return response.StatusCode == HttpStatusCode.OK;
		}
	}
