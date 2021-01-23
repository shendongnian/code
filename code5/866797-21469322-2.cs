    const long PageSizeLimit = 1000000;
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.stackoverflow.com");
    request.Method = "HEAD";
    long pageSize;
    
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    {
    	pageSize = response.ContentLength;
    }
    
    if (pageSize < PageSizeLimit)
    {
    	// download page
    }
