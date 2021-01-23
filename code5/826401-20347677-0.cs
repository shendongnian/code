    var url = "http://....";
    //OR
    var url = service_object.Url;
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Timeout = 2000; //timeout 20 seconds
    HttpWebResponse response = null;
    try
    {
    	response = (HttpWebResponse)request.GetResponse();
    	if (response.StatusCode != HttpStatusCode.OK)
    	{
    		throw new ApplicationException(response.StatusDescription);
    	}
    }
    catch (ApplicationException ex)
    {
    	//Do what you want here, create a file for example...
    }
