    using System;
    using System.Net;
    using System.IO;
    
        using (WebClient client = new WebClient())
        {
            string htmlCode = client.DownloadString("http://somesite.com/default.html");
            File.WriteAllText(@"c:\YourLocalFolder\somefile.txt", htmlCode);
        }
