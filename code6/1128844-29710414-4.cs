    void DownloadFile()
    {
        WebClient client = new WebClient();
        client.DownloadFileCompleted += System.ComponentModel.AsyncCompletedEventHandler( DownloadFileCompleted );
        client.DownloadFileAsync ("http://ServerInfo.net/moviefile.mp4", Application.persistentDataPath + "/" + "moviefile.mp4");
    }
    void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            AllDone ();
        }
    }
