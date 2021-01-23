    static DownloadedImage GetImageFromWeb(string uriString)
    {
      var webClient = new WebClient();
      var uri = new Uri(uriString);
      Image image = null;
      using (var stream = webClient.OpenRead(uri))
      {
        image = Image.FromStream(stream);
        stream.Close();
      }
 
      var downloadedImage = new DownloadedImage
      {
        Uri = uri,
        Image = image
      };
    
      return downloadedImage;
    }
