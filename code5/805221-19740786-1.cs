    var _downloadQueue = new Queue<Uri>();
    var _webClient = new WebClient();
 
    //in your constructor:
    _webClient.DownloadProgressChanged += Descarcare_DownloadProgressChanged;
    _webClient.DownloadFileCompleted += Descarcare_DownloadFileCompleted;
    private void Foo()
    {
        //...
        foreach(/* condition */) 
        {
            _downloadQueue.Enqueue(
                new Uri(nod.SelectSingleNode("DownloadLink").InnerText)
            );                                    
        }
        DownloadNext();
    }
    private void DownloadNext()
    {
        if(_downloadQeue.Count> 0)
        {
            _webClient.DownloadFileAsync(
                _downloadQueue.Dequeue(), Directory.GetCurrentDirectory()
            );
        }
    }
    void Descarcare_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        DownloadNext();
        //extract the file
        //...
    }
