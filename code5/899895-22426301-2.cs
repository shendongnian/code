    using System.IO;
    using System.Net;
    
    String URI = "http://somesite.com/somepage.html";
    
    WebClient webClient = new WebClient();
    Stream stream = webClient.OpenRead(URI);
    String request = reader.ReadToEnd();
