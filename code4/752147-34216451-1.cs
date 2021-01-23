	var webRequest = (HttpWebRequest)WebRequest.Create(url);
	webRequest.CookieContainer = Cookies;
	//webRequest.Headers.Add(HeaderCollection); 
	webRequest.Timeout = 10000;
	//webRequest.UserAgent = UserAgent;
	webRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
	webRequest.Method = "POST";
	byte[] postBytes;
	if (postDataRaw != null) {
		postBytes = Encoding.UTF8.GetBytes(postDataRaw);
	}
	webRequest.ContentLength = postBytes.Length;
	using (var dataStream = webRequest.GetRequestStream()) {
		dataStream.Write(postBytes, 0, postBytes.Length);
	}
	using (var response = webRequest.GetResponse()) {
		var result = ((HttpWebResponse)response).StatusCode;
		using (var responseStream = response.GetResponseStream()) {
			using (var streamReader = new StreamReader(responseStream)) {
				return streamReader.ReadToEnd();
			}
		}
	}
