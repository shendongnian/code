    private async Task<T> GenericApiRequestAsync<T>(string command, string query)
    {
        HttpClient client = new HttpClient();
		
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	
        Uri uri = new Uri(string.Format("{0}/api/{1}/?cmd={2}{3}", apiUrl, apiKey, command, query));
		
        try {	
            HttpResponseMessage response = await client.GetAsync(uri);                
            response.EnsureSuccessStatusCode();
			
            var responseContent = await response.Content.ReadAsStringAsync();
			
            // Convert responseContent via MyCustomResponseConverter
            var myCustomResponse = 
                    await Task.Factory.StartNew(() =>
                                           JsonConvert.DeserializeObject<MyCustomResponse(
                                               responseContent, 
                                               new MyCustomResponseConverter<T>()
                                           ));
			
            return (T)myCustomResponse.Data;
        }
        catch(Exception ex)
        {
			... 
        }
    }
