    void Main()
    {
    	try
    	{	        
    		using(var wc = new WebClient()){
    	   		wc.DownloadString(Util.ReadLine("sitename?")).Dump("success");
    		}
    	}
    	catch (WebException ex)
    	{
    		string response;
    		using(var stream=ex.Response.GetResponseStream())
    		using(var sr = new StreamReader(stream))
    		{
    			response=sr.ReadToEnd();
    		}
            response.Dump("error");
    	}
    	
    }
