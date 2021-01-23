    /// <summary>
    ///     Initialize the POST HTTP request.
    /// </summary>
    public void SentPostReport()
    {
        string url = "http://MyUrlPerso.com/";
        Uri uri = new Uri(url);
        // Create a boundary for HTTP request.
        Boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
        
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        request.ContentType = "multipart/form-data; boundary=" + Boundary;
        request.Method = "POST";
        request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), est);
            allDone.WaitOne();
    }
