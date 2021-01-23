    public static void Testing()
    {
        var c = new HttpClient
        {
            BaseAddress = new Uri("http://www.testing.co.uk/Services/Service.svc/")
        };
        c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var json = "{\"login\":{\"DeviceId\":\"\",\"Password\":\"123\",\"Username\":\"abc\",\"DeviceModel\":\"\"}}";
        var req = new HttpRequestMessage(HttpMethod.Post, "TestLogin")
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        c.SendAsync(req).ContinueWith(respTask =>
        {
            var response = respTask.Result.Content.ReadAsStringAsync();
            Console.WriteLine("Response: {0}", respTask.Result);
        });
    }
