    var request = (HttpWebRequest)WebRequest.Create("http://google.com");
    request.Proxy = new WebProxy();
    request.Proxy = new WebProxy("IP", port);
    var response = (HttpWebResponse)request.GetResponse();
    
    using (var stream = response.GetResponseStream())
    {
        if (stream != null)
        {
            using (var streamReader = new StreamReader(stream))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }
    }
