    HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
    // End the operation
    Stream postStream = request.EndGetRequestStream(asynchronousResult);
    //postData value
    string postData = "xxxxxxxxxx";  
    // Convert the string into a byte array. 
    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    // Write to the request stream.
    postStream.Write(byteArray, 0, postData.Length);
    postStream.Close();
    // Start the asynchronous operation to get the response
    request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
