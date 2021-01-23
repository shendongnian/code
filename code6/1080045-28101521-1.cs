    using (HttpClient Client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://192.168.1.152/");
        HttpResponseMessage Response = await Client.GetAsync("MyWebServer");
        // use Response as needed...
    }
