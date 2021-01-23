    var payload = new Credentials { 
        Agent = new Agent { 
            Name = "Agent Name",
            Version = 1 
        },
        Username = "Username",
        Password = "User Password",
        Token = "xxxxx"
    };
    
    // Serialize our concrete class into a JSON String
    var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(payload));
    
    // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
    var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
    
    using (var httpClient = new HttpClient()) {
        
        // Do the actual request and await the response
        var httpResponse = await httpClient.PostAsync("http://localhost/api/path", httpContent);
        
        // If the response contains content we want to read it!
        if (httpResponse.Content != null) {
            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            
            // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
        }
    }
