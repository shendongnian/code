    private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
    {
        Dispatcher.BeginInvoke(() => 
        {
            MessageBox.Show("inside get request stream");
        });
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
        // End the operation
        Stream postStream = request.EndGetRequestStream(asynchronousResult);
        //Console.WriteLine("Please enter the input data to be posted:");
        string postData = "Message = Hello";
        // Convert the string into a byte array. 
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        // Write to the request stream.
        postStream.Write(byteArray, 0, postData.Length);
        postStream.Close();
        // Start the asynchronous operation to get the response
        request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
    }
    private void GetResponseCallback(IAsyncResult asynchronousResult)
    {
        Dispatcher.BeginInvoke(() => 
        {
            MessageBox.Show("inside get response");
        });
        HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
        // End the operation
        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
        Stream streamResponse = response.GetResponseStream();
        StreamReader streamRead = new StreamReader(streamResponse);
        string responseString = streamRead.ReadToEnd();
        Console.WriteLine(responseString);
        // Close the stream object
        streamResponse.Close();
        streamRead.Close();
        // Release the HttpWebResponse
        response.Close();
        allDone.Set();
    }       
