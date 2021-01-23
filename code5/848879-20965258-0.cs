    private async void loggingIn(string url, string postdata)
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    try
                    {
                     var request = HttpWebRequest.Create(url) as HttpWebRequest;  
                     request.Method = "POST";
                     request.Accept = "application/json";
                     request.ContentType = "application/json";
                     request.BeginGetRequestStream(loginRequest, request);
                     }
                     catch(Exception ex) 
                    {
                    }
           }
         private void loginRequest(IAsyncResult asyncResult)
          {
           string postdata = "password=" + password +"&username="+username;
           UTF8Encoding encoding = new UTF8Encoding();
           HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
           Stream _body = request.EndGetRequestStream(asyncResult);
           byte[] formBytes = encoding.GetBytes(postdata);
           _body.Write(formBytes, 0, formBytes.Length);
           _body.Close();
            request.BeginGetResponse(loginResponse, request);
          }
        
         private void loginResponse(IAsyncResult asyncResult)
          {
             try
              {
                HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);
                HttpWebResponse httpResponse = (HttpWebResponse)response;
                using (Stream data = response.GetResponseStream())
                using (var reader = new StreamReader(data))
                {
                string received = await reader.ReadToEndAsync();
                MessageBox.Show(received);
                }
              }
              catch(Exception ex)
             {
             }
         }
