    private void ReadUrlAsync()
        {
        var request = HttpWebRequest.Create(request_url) as HttpWebRequest;                
            request.Accept = "application/json;odata=verbose";
            request.BeginGetResponse(ResponseCallback, request);
        }
        
    private void ResponseCallback(IAsyncResult asyncResult)
      {
         HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
         HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);
         using (Stream responseStream= response.GetResponseStream())
           {
             string data;
             using (var reader = new System.IO.StreamReader(responseStream))
              {
                data = reader.ReadToEnd();
              }
           }
      }
