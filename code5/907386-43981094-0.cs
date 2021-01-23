    using (HttpClient client = new HttpClient())
        {
    	    using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    var byteArray = response.Content.ReadAsByteArrayAsync().Result;
                    var result = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                    return result;
                }
    	}
