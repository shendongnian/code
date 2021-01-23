    using System.Net;
    //...
    using (WebClient webClient = new WebClient ())
    {
        client.DownloadFile("http://yoursite.com/page.html", @"C:\localfile.html");
    
        // Or you can get the file content without saving it:
        string htmlCode = client.DownloadString("http://yoursite.com/page.html");
        //...
    }
