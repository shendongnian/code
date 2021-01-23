    void Main()
    {
    	const long PageSizeLimit = 1000000;
    	var url = "http://www.stackoverflow.com";
    	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    	request.Method = "HEAD";
    	long pageSize;
    	string page;
    
    	using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    	{
    		pageSize = response.ContentLength;
    	}
    	
    	// if content lenth is not present -> get full page
    	if (pageSize > 0 && pageSize < PageSizeLimit)
    	{
    		page = DownloadPage(url);
    		ProcessPage(page);
    	}
    	else
    	{
    		page = DownloadPage(url);
    			
    		if (page.Length < PageSizeLimit)
    		{
    			ProcessPage(page);
    		}
    	}
    }
    
    public string DownloadPage(string url)
    {
    	using (var webClient = new WebClient())
    	{			
    		return webClient.DownloadString(url);
    	}
    }
    
    public void ProcessPage(string page)
    {
    	// do your processing
    }
