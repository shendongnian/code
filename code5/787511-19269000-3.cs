    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        // Create a new HttpWebRequest object.
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.example.com/webservicelogin/webservice.asmx/ReadTotalOutstandingInvoice");
    
        request.ContentType = "application/x-www-form-urlencoded";
        request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0; Touch)";
        request.CookieContainer = cookie;
    
        // Set the Method property to 'POST' to post data to the URI.
        request.Method = "POST";
    
        // start the asynchronous operation
        request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
    
    }
    
    private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
    {
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
    
    }
    
    private void GetResponseCallback(IAsyncResult asynchronousResult)
    {
    
                HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
                // End the operation
    
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
    
                Stream streamResponse = response.GetResponseStream();
    
                StreamReader streamRead = new StreamReader(streamResponse);
                string read = streamRead.ReadToEnd();
    
                //respond from httpRequest
                TextBox.Text = read;
    
                // Close the stream object
                streamResponse.Close();
                streamRead.Close();
                response.Close();
    }
    
     
       
