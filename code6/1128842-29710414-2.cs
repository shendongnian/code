    WebClient client = new WebClient();
    client.DownloadFileCompleted += new AsyncCompletedEventHandler( DownloadFileCompleted );
    client.DownloadFileAsync ("http://ServerInfo.net/moviefile.mp4", Application.persistentDataPath + "/" + "moviefile.mp4");
    void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            AllDone ();
        }
    }
