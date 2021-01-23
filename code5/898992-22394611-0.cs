      var client = new WebClient();
     
      client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(loadHTMLCallback);
      client.DownloadStringAsync(new Uri("http://www.myurl.com/myFile.txt"));
    //...
     
    public void loadHTMLCallback(Object sender, DownloadStringCompletedEventArgs e)
    {
      var textData = (string)e.Result;
      // Do cool stuff with result
      Debug.WriteLine(textData);
    }
