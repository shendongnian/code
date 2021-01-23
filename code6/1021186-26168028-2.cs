	[TestMethod, TestCategory("WebServices")]
	public void ValidateWebServiceGetUserAuthToken()
	{
		string _jsonstringparams =
			"{ \"Password\": \"xxx\", \"UserId\": \"xxxx\"}";
		using (var _requestclient = new WebClient())
		{
			_requestclient.UploadStringCompleted += _requestclient_UploadStringCompleted;
			var _uri = String.Format("{0}?format=Json", _webservicesurl);
			_requestclient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
			_requestclient.UploadStringAsync(new Uri(_uri), "POST", _jsonstringparams);
			completedEvent.WaitOne();
		}
	}
	private ManualResetEvent completedEvent = new ManualResetEvent(false);
	void _requestclient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
	{
		if (e.Result != null)
		{
			var _responsecontent = e.Result.ToString();
			Console.WriteLine(_responsecontent);
		}
		else
		{
			Assert.IsNotNull(e.Error.Message, "Test Case Failed");
		}
		completedEvent.Set();
	}
