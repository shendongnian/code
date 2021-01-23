    using System.Net;
    //...
    using (WebClient client = new WebClient ()) // WebClient class inherits IDisposable
    {
        string htmlCode = client.DownloadString("http://plug.dj");
    }
