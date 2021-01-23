    var client = new HttpClient
    {
        BaseAddress = new Uri(API_URL)
    };
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
        "Basic",
        Convert.ToBase64String(Encoding.UTF8.GetBytes("8139E7541722F5D91ED8FB15165F4:")));
