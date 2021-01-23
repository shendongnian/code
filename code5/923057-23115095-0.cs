    using (WebClient client = new WebClient())
    {
         NameValueCollection nvc = new NameValueCollection()
         {
             { "foo", "bar"}
         };
         byte[] responseBytes = client.UploadValues("http://www.google.com", nvc);
         string response = System.Text.Encoding.ASCII.GetString(responseBytes);
    }
