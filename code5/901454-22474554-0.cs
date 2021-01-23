    public void SendPost(string url, string postData)
      {
          WebClient client = new WebClient();
          client.UploadStringCompleted += client_UploadStringCompleted;
          client.UploadStringAsync(new Uri(url), postData);
          
      }
    void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            // error in uploading
        }
    }
