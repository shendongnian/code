    private static async Task GetData()
    {
        string content;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:23306/");
            client.DefaultRequestHeaders.Accept.Clear();
    
            HttpResponseMessage response = await client.GetAsync("home/get");
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<byte[]>(content);
            }
        }
    }
