	try
	{
	   using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
	   {
		  WebHeaderCollection headers = response.Headers;    
		  using (Stream answer = response.GetResponseStream())
		  {
			  // Do stuff
		  }
	   }
	}
	catch (WebException e)
	{
	   if (e.Status == WebExceptionStatus.Timeout)
	   {
		  // Handle timeout exception
	   }
	   else throw;
	}
