    // ...
    
    string payload = JsonConvert.SerializeObject(new
    {
        agent = new
        {
            name    = "Agent Name",
            version = 1,
        },
    
        username = "username",
        password = "password",
        token    = "xxxxx",
    });
    
    var client = new HttpClient();
    var content = new StringContent(payload, Encoding.UTF8, "application/json");
    
    HttpResponseMessage response = await client.PostAsync(uri, content);
    
    // ...
