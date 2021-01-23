    System.Net.WebRequest req = System.Net.HttpWebRequest.Create("http:\\your\url.ext");
    req.Method = "HEAD";
    using (System.Net.WebResponse resp = req.GetResponse())
    {
        DateTime LastModified;
        if(DateTime.TryParse(resp.Headers.Get("Last-Modified"), out LastModified))
        { 
            //Check if date is good and then go to full download method.
        }
    }
