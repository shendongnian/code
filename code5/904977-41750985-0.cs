	public async Task<string> SendMessageJSON(string message, string url)
	{
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
        request.ContentType = "application/json";
        request.Method = "POST";
        // Send data to server
        IAsyncResult resultRequest = request.BeginGetRequestStream(null, null);
        resultRequest.AsyncWaitHandle.WaitOne(30000); // 30 seconds for timeout
        Stream streamInput = request.EndGetRequestStream(resultRequest);
        byte[] byteArray = Encoding.UTF8.GetBytes(message);
        await streamInput.WriteAsync(byteArray, 0, byteArray.Length);
        await streamInput.FlushAsync();
        // Receive data from server
        IAsyncResult resultResponse = request.BeginGetResponse(null, null);
        resultResponse.AsyncWaitHandle.WaitOne(30000); // 30 seconds for timeout
        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(resultResponse);
        Stream streamResponse = response.GetResponseStream();
        StreamReader streamRead = new StreamReader(streamResponse);
        string result = await streamRead.ReadToEndAsync();
        await streamResponse.FlushAsync();
    	return result;
	}
