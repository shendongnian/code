    private static string GetItem(string sItemName, string url)
    {
        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            XElement content = response.Content.ReadAsAsync<XElement>().Result;
            ...
              
