    void sendRequest()
    {
       Uri myUri = new Uri(http://www.yourwebsite.com);
       HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(myUri);
       myRequest.Method = AppResources.POST;
       myRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), myRequest);
    }
    
    void GetRequestStreamCallback(IAsyncResult callbackResult)
    {
    	HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;
    
    	// End the stream request operation
    	Stream postStream = myRequest.EndGetRequestStream(callbackResult);
    
    	// Create the post data
    	string postData = "INSERT HERE THE JASON YOU WANT TO SEND";
    	byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
    	// Add the post data to the web request
    	postStream.Write(byteArray, 0, byteArray.Length);
    	postStream.Close();
    
    	// Start the web request
    	myRequest.BeginGetResponse(new AsyncCallback(GetResponsetStreamCallback), myRequest);
    }
    
     void GetResponsetStreamCallback(IAsyncResult callbackResult)
     {
         lib = new ApiLibrary();
    
         try
         {
             HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
             HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
             string result = "";
             using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
             {
                 result = httpWebStreamReader.ReadToEnd();
             }
    
                string APIResult = result;
    				
             }
             catch (Exception e)
             {
    			
          }
       }
