    public string GetFilenameFromWebServer(string url)
    {
    	string result = "";
    
    	var req = System.Net.WebRequest.Create(url);
    	req.Method = "HEAD";
    	using (System.Net.WebResponse resp = req.GetResponse())
    	{
    		// Try to extract the filename from the Content-Disposition header
    		if (!string.IsNullOrEmpty(resp.Headers["Content-Disposition"]))
    		{
    			result = resp.Headers["Content-Disposition"].Substring(resp.Headers["Content-Disposition"].IndexOf("filename=") + 9).Replace("\"", "");
    		}
    	}
    
    	return result;
    }
