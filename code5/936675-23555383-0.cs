        using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://xyzxyz.azurewebsites.net/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        HttpResponseMessage response = await client.GetAsync("api/user/1");
        if (response.IsSuccessStatusCode)
        {
            //add your code
        }
    }
