    WebClient wc = new WebClient();
    var data=   wc.DownloadData(@"www.sometime.com\getfile?id=123");
    string filename = "";
    
    // Try to extract the filename from the Content-Disposition header
    if (!String.IsNullOrEmpty(wc.ResponseHeaders["Content-Disposition"]))
    {
     fileName = wc.ResponseHeaders["Content-Disposition"].Substring(wc.ResponseHeaders["Content-Disposition"].IndexOf("filename=") + 10).Replace("\"", "");
    }
