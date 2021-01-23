    using (HttpClient client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost:23302");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync("api/useraccount").Result;
        if (response.IsSuccessStatusCode)
        {
            var t = response.Content.ReadAsAsync<IEnumerable<UserAccount>>().Result;
            ...
        }
        else
        {
            //Something has gone wrong, handle it here
        }
    }
