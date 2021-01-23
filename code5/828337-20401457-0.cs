    var url = "http://google.com";
    var content = "";
    
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:24.0) Gecko/20100101 Firefox/24.0";
    request.AutomaticDecompression = DecompressionMethods.GZip;
    
    // Timeout set to 30 seconds.
    request.Timeout = 30 * 1000;
    
    var response = (HttpWebResponse)request.GetResponse();
    
    using (var stream = response.GetResponseStream())
    {
        if (stream != null)
        {
            using (var streamReader = new StreamReader(stream))
            {
                content = streamReader.ReadToEnd();
            }
        }
    }
    response.Close();
    Console.WriteLine (content);
