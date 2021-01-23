    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:58295/fetch_information");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
    login_info_request req = ... 
    string postBody = JsonConvert.SerializeObject(req);
    HttpContent content = new StringContent(postBody, Encoding.UTF8, "application/json");
    HttpResponseMessage response = client.PostAsync("api/" + request, content).Result;
    if (response.IsSuccessStatusCode)
    {
        // Read the response body as string
        string json = response.Content.ReadAsStringAsync().Result;
    
        // deserialize the JSON response returned from the Web API back to a login_info object
        return JsonConvert.DeserializeObject<login_info>(json);
    }
    else
    {
        return null;
    }
