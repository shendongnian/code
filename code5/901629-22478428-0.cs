        public void testSend()
      {
                  string url = "";
                  string str = "test";
                  HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                  req.Method = "POST";
                  string Data = "data=" + str;
                  byte[] postBytes = Encoding.UTF8.GetBytes(Data);
                  req.ContentType = "application/x-www-form-urlencoded";
                  req.ContentLength = postBytes.Length;
                  Stream requestStream = req.GetRequestStream();
                  requestStream.Write(postBytes, 0, postBytes.Length);
                  requestStream.Close();
    
                  HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                  Stream resStream = response.GetResponseStream();
    
                  var sr = new StreamReader(response.GetResponseStream());
                  string responseText = sr.ReadToEnd();
                  WebClient client = new WebClient();
                  client.UploadStringCompleted += client_UploadStringCompleted;
                  client.UploadStringAsync(new Uri(url), responseText);
    
      }
    
    void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            // error in uploading
        }
    }
