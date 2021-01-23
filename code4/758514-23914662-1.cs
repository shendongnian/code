    using System.Net.Http.Headers; // For AuthenticationHeaderValue
    const string uri = "https://example.com/path?params=1";
    using (var client = new HttpClient()) {
        var byteArray = Encoding.ASCII.GetBytes("MyUSER:MyPASS");
        var header = new AuthenticationHeaderValue(
                   "Basic", Convert.ToBase64String(byteArray));
        client.DefaultRequestHeaders.Authorization = header;
        var result = await client.GetStringAsync(uri);
    }
