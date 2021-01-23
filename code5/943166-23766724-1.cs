    public static class RequestDeserializer
    {
    	public static T SendRequestAndDeserialize<T>(string url) where T : new()
    	{
    		var request = WebRequest.Create(url);
            var response = request.GetResponse();
    
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(response.GetResponseStream());
    	}
    }
