    using (var client = new HttpClient())
    {
        using (var content = new MultipartFormDataContent())
        {
            client.BaseAddress = new Uri("http://localhost:54711/");
            content.Add(new StreamContent(File.OpenRead(@"d:\foo.jpg")), "foo", "foo.jpg");
            var parameters = new FeedItemParams()
            {
                Id = "1234",
                Comment = "Some comment about this or that."
            };
            content.Add(new ObjectContent<FeedItemParams>(parameters, new JsonMediaTypeFormatter()), "parameters");
            var result = client.PostAsync("/api/Values", content).Result;
        }
    }
