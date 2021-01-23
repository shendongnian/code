    public void DLTest()
    {
        string url = "http://www.sciencelab.com/msds.php?msdsId=9927335";
        string clientfile = @"C:\Test\newfile.pdf";
        WebClient wc = new WebClient();
        wc.DownloadFile(new Uri(url, UriKind.Absolute), clientfile);
    }
