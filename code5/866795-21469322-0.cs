    const long PageSizeLimit = 100000;
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.stackoverflow.com");
    request.Method = "HEAD";
    
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    long pageSize = response.ContentLength;
    
    if (pageSize < PageSizeLimit)
    {
    	// download page
    }
