    private static byte[] DownloadRemoteImageFile(string uri)
    {
    	byte[] content;
    	var request = (HttpWebRequest)WebRequest.Create(uri);
    
    	using(var response = request.GetResponse())
    	using (var reader = new BinaryReader(response.GetResponseStream()))
    	{
    		content = reader.ReadBytes(100000);
    	}
    
    	return content;
    }
