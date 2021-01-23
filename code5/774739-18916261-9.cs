       public event EventHandler<Response> LoginComplete;
       void sampleRequest(){
          //identical original one
          ....
        }
        private void GetLoginCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                HttpWebResponse httpresponse = (HttpWebResponse)httpRequest.EndGetResponse(asynchronousResult);
                ...
                
                  //Dispatch request back to ui thread
                  Deployment.Current.Dispatcher.BeginInvoke(() =>
                  {
                       if (LoginComplete != null)
                       {
                            LoginComplete(this,response);
                       }
                   });
                
            }
            catch (WebException ex)
            {
            }
        }
