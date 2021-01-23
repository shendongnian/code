    public  void testSend()
      {
          try
          {
              string url = "abc.com";
              string str = "test";
              HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
              req.Method = "POST";
              req.ContentType = "text/plain; charset=utf-8";
              req.BeginGetRequestStream(SendRequest, req);
          }
          catch (WebException)
          {
    
          }
    }
    //Get Response and write body
     private void SendRequest(IAsyncResult asyncResult)
            {
              string str = "test";
              string Data = "data=" + str;
              HttpWebRequest req= (HttpWebRequest)asyncResult.AsyncState;
              byte[] postBytes = Encoding.UTF8.GetBytes(Data);
              req.ContentType = "application/x-www-form-urlencoded";
              req.ContentLength = postBytes.Length;
              Stream requestStream = req.GetRequestStream();
              requestStream.Write(postBytes, 0, postBytes.Length);
              requestStream.Close();
              request.BeginGetResponse(SendResponse, req);
            }
    //Get Response string
     private void SendResponse(IAsyncResult asyncResult)
            {
                try
                {
                    MemoryStream ms;
    
                    HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
                    HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    string _responestring = string.Empty;
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        _responestring = reader.ReadToEnd();
                     }
                  }
           catch (WebException)
          {
    
          }
       }
