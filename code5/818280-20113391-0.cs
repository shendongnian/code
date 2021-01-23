    string url = "http://myserver.com/?page=hello&param2=val2";
        // HTTP web request
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        httpWebRequest.Method = "POST";
        httpWebRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), webRequest);
        }
        private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
            using (var postStream = webRequest.EndGetRequestStream(asynchronousResult))
            {
               //send yoour data here
            }
            webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), webRequest);
        }
        void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest myrequest = (HttpWebRequest)asynchronousResult.AsyncState;
                using (HttpWebResponse response = (HttpWebResponse)myrequest.EndGetResponse(asynchronousResult))
                {
                    System.IO.Stream responseStream = response.GetResponseStream();
                    using (var reader = new System.IO.StreamReader(responseStream))
                    {
                        data = reader.ReadToEnd();
                    }
                    responseStream.Close();
                }
            }
            catch (Exception e)
            {
      //Handle Exception
                }
                else
                    throw;
            }
        }
