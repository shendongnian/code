    using (var client = new HttpClient())
    {
        var myObject = new MyPostObject(){Id =XXXX, Array = YYYYY};
        using (var response = await client.PostAsJsonAsync("api/CONTROLLER/METHOD", myObject))
        using (var content = response.Content)
        {
            var result = content.ReadAsAsync<LoginModelResponse>().Result;
        }
    }
