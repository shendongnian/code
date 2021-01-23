    MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
    HttpContent datas = new ObjectContent<dynamic>(new { 
        username= username, 
        password= password}, jsonFormatter);
            
    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    var response = client.PostAsync("api/User/ValidateAdmin", datas).Result;
    if (response != null)
    {
        try
        {
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<bool>().Result;
            ...
