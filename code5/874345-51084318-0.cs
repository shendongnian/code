    var client = new HttpClient();
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
    "ENVIRONMENT_KEY:ACCESS_SECRET");
    var content = new StringContent(data, Encoding.UTF8, "application/json");
    var response = client.PostAsync(url, content).Result;
            
    string responseJson;
    using (HttpContent resp = response.Content)
    {
        responseJson = resp.ReadAsStringAsync().Result; 
    }
    return responseJson;
