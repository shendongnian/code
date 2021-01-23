    static void Main(string[] args)
    {
        using (WebClient client = new WebClient())
        {
           client.DownloadFile("http://yoursite.com/page.html",
                               @"C:\localfile.html");
        }
    }
