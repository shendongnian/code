     var handler = new ManualResetEvent(false);
     request = (HttpWebRequest)WebRequest.Create(url)
     {
        // initialize parameters such as method
     }
    
     request.BeginGetResponse(new AsyncCallback(delegate(IAsyncResult result)
     {
          try
          {
              var request = (HttpWebRequest)result.AsyncState;
              using (var response = (HttpWebResponse)request.EndGetResponse(result))
              {
                  using (var stream = response.GetResponseStream())
                  {
                      // success 
                  }
                  response.Close();
              }
          }
          catch (Exception e)
          {
              // fail operations go here
          }
          finally
          {
              handler.Set(); // whenever i succedd or fail
          }
     }), request);
     handler.WaitOne(); // wait for the operation to complete
    
