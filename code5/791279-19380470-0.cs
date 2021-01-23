    internal static async Task<bool> ValidateUrl(string url)
    {
      Uri validUri;
      if(Uri.TryCreate(url,UriKind.Absolute,out validUri))
      {
        var client = new HttpClient();
    
    	try
    	{                    
    	  var response = await client.GetAsync(validUri, HttpCompletionOption.ResponseHeadersRead);
    	  response.EnsureStatusIsSuccessful();
    	  return true;
    	}
    	catch (Exception)
    	{
    	}
    	
    	return false;
      }
     }
