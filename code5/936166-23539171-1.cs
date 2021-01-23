	string valueString = "...";
	string uriString = "http://someUrl/somePath";
	HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uriString);
	httpWebRequest.Method = "POST";
	string postData = "key=" + Uri.EscapeDataString(valueString);
	byte[] byteArray = Encoding.UTF8.GetBytes(postData);
	httpWebRequest.ContentType = "application/x-www-form-urlencoded";
	httpWebRequest.ContentLength = byteArray.Length;
	using (Stream dataStream = httpWebRequest.GetRequestStream())
	{
		// do pausing and stuff here by using a while loop and changing byteArray.Length into the desired length of your chunks
		dataStream.Write(byteArray, 0, byteArray.Length);
	}
	HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
	Stream receiveStream = httpWebResponse.GetResponseStream();
	StreamReader readStream = new StreamReader(receiveStream);
	string internalResponseString = readStream.ReadToEnd();
