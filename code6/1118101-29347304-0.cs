    var uri = new Uri("ftp://ftp.host.com/name.txt"); //no credentails in url
    using (var webClient = new System.Net.WebClient())
    {
        webClient.Credentials = new System.Net.NetworkCredential("user", "pass");
        webClient.DownloadFile(uri, @"C:\inetpub\wwwroot\name.txt");
    }
