    void sendWebRequest()
         {
             WebClient webClient = new WebClient();
             String data = "";//data to upload
             String url="";
             webClient.UploadStringCompleted += webClient_UploadStringCompleted;
             webClient.UploadStringAsync(new Uri(url), data);
         }
         void webClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
         { }
