    var client = new WebClient { Credentials = new NetworkCredential("username", "password") };
    try
    {
      var data = client.DownloadData(<some uri to a file path on the ftp site>);
      ...
    }
    catch (WebException e)
    {
      // handle any exceptions
    }
