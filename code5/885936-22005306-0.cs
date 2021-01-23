    private void GetErrorCode(string url)
    {
    	try
    	{
    		string htmlString = new WebClient().DownloadString(url);
    		Console.WriteLine(htmlString);
    	}
    	catch (WebException webExp)
    	{
    		Console.WriteLine("You got a {0} error!", (int)((HttpWebResponse) webExp.Response).StatusCode);
    	}
    			
    	Console.ReadKey();
    }
