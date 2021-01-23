	[TestMethod, TestCategory("WebServices")]
	public async Task ValidateWebServiceGetUserAuthToken()
	{
		string _jsonstringparams =
			"{ \"Password\": \"xxx\", \"UserId\": \"xxxx\"}";
		using (var httpClient = new HttpClient())
		{
			var _uri = String.Format("{0}?format=Json", _webservicesurl);
			var stringContent = new StringContent(_jsonstringparams);
			stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json"); 
			HttpResponseMessage response = await httpClient.PostAsync(_uri, stringContent);
			// Or whatever status code this service response with
			Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
			var responseText = await response.Content.ReadAsStringAsync();
			// TODO: something more specific to your needs
			Assert.IsTrue(!string.IsNullOrWhiteSpace(responseText));
		}
	}
