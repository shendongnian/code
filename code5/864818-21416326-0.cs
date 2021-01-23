    using (var webClient = new WebClient())
    {
      var text = webClient.DownloadString(url);
    
      // Case-insensitive comparison of the downloaded data to 'something'
      if (string.Equals(text, something, StringComparison.OrdinalIgnoreCase))
      {
         // Do something here...
      }
    }
