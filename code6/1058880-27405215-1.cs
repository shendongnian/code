    var ThreadSafeList = new System.Collections.Concurrent.ConcurrentBag<string>();
    Parallel.ForEach(Arguments, Argument =>
    {
        if (Argument != Command_Name)
        {
            WebRequest web_request = WebRequest.Create("https://www.aol.com/?command=1&domain=" + Argument);
            web_request.Timeout = 5000;
            ((HttpWebRequest)web_request).UserAgent = "Mozilla Firefox 5.0";
            HttpWebResponse web_response = (HttpWebResponse)web_request.GetResponse();
            StreamReader response = new StreamReader(web_response.GetResponseStream(), Encoding.UTF8);
            ThreadSafeList.Add(Argument + " => " + response.ReadToEnd());                    
        }
    });
    string Result = string.Join("", ThreadSafeList);
 
