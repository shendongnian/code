    var c = new HttpClient
    {
        BaseAddress = new Uri("Your URL")
    };
    
    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    var json = "Your json string"
    var req = new HttpRequestMessage(HttpMethod.Post, "Your Method name in URI Template")
    {
        Content = new StringContent(json, Encoding.UTF8, "application/json")
    };
    c.SendAsync(req).ContinueWith(respTask =>
    {
        var response = respTask.Result.Content.ReadAsStringAsync();
        Console.WriteLine("Response: {0}", respTask.Result);
    });
    }
