    public T Get()
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(Config.API_BaseSite);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/myapplicaton/products").Result;
            if (!response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAync().Result;
                throw new HttpException((int)response.StatusCode, responseBody);
            }
            T res = response.Content.ReadAsAsync<T>().Result;
            return (T)res;
        }
    }
