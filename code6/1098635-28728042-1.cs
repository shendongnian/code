    using System.Net;
    using (WebClient webClient = new WebClient())
    {
        webClient.DownloadFile(URL, @"C:\file.pdf");
    }
