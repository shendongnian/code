    public void DLTest()
    {
        string url = "https://www.osha.gov/Publications/Abate/abate.pdf";
        string clientfile = @"C:\Test\newfile3.pdf";
        WebClient wc = new WebClient();
        wc.DownloadFile(new Uri(url, UriKind.Absolute), clientfile);
    }
