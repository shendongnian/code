	public static async Task<TRes> Post<TReq, TRes>(string url, TReq data, HttpClient httpClient)
	{
		HttpContent content = ToJsonHttpContent(data);
		HttpResponseMessage response = await httpClient.PostAsync(url, content);
		response.EnsureSuccessStatusCode();
		return await response.Content.Extract<TRes>();
	}
    public static async Task<T> Extract<T>(this HttpContent me)
    {
    	DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
    	using (Stream stream = await me.ReadAsStreamAsync())
    	{
    		return (T)serializer.ReadObject(stream);
    	}
    }
    
    public static HttpContent ToJsonHttpContent(object data)
    {
    	string jsonData = JsonConvert.SerializeObject(data);
    	return new StringContent(jsonData, Encoding.UTF8, "application/json");
    }
