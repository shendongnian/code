    var data = "{\"Id\":0,\"Count\":0,\"StartDate\":\"\\/Date(-62135596800000)\\/\",\"Address\":{\"Id\":0,\"State\":\"test\",\"City\":\"test\"}}";
    
    using (var client = new HttpClient())
    {
        HttpContent content = new StringContent(data);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    
        HttpResponseMessage response =
            client.PostAsync("http://my.url", content).Result;
        var result = response.Content.ReadAsStringAsync().Result;
    }
