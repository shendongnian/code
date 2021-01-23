    public void DoUIThings()
    {
         // Do some UI related things.
         acquireToken();
         // Don't continue doing things here.... Wait for the ContinueDoUIThings() to be called.
    }
    public void ContinueDoUIThings()
    {
          // Now use your newly created token here...
          // Do some UI related things.
          // Note that this is called from below.
    }
    public void aquireToken() 
    {
        // .... Your code was here..
        apiR.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), apiR);
    }
    private void GetRequestStreamCallback(IAsyncResult callbackResult)
    {
        /// Your code was here.....
        myRequest.BeginGetResponse(new AsyncCallback(GetResponsetStreamCallback), myRequest);
    }
    private void GetResponsetStreamCallback(IAsyncResult callbackResult)
    {
        HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
        using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
        {
            string result = httpWebStreamReader.ReadToEnd();
            var u = JsonConvert.DeserializeObject<dynamic>(result);
            //string jsondata = u.data.toString();
            NTUser.token = JsonConvert.DeserializeObject<Token>(u.data.ToString());
            
            // Added this call here...
            ContinueDoUIThings();
        }
    }
