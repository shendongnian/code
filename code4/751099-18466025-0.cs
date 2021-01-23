        class HTTPReqRes
        {
        private static HttpWebRequest webRequest;
        public static void SendRequest()
        {
            webRequest = (HttpWebRequest)HttpWebRequest.CreateHttp("https://www.mydomain.com");
            webRequest.Method = "PUT";
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.Headers["Header1"] = "Header1Value";
           
            String myXml = "<Roottag><info>test</info></Roottag>";
            // Convert the string into a byte array. 
            byte[] byteArray = Encoding.UTF8.GetBytes(myXml);
            webRequest.ContentLength = byteArray.Length;
           
            // start the asynchronous operation
            webRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), webRequest);                  
            //webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), webRequest);
        }
        private static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);
            String myXml = <Roottag><info>test</info></Roottag>";
            // Convert the string into a byte array. 
            byte[] byteArray = Encoding.UTF8.GetBytes(myXml);
            // Write to the request stream.
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();
            // Start the asynchronous operation to get the response
            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }
        private static void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the operation
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
            System.Diagnostics.Debug.WriteLine(responseString);
            // Close the stream object
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse
            response.Close();
        }
    }
