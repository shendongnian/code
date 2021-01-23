    public async Task<U> PostAsync<T, U>(string url, T model)
    {
        using (HttpClient httpClient = new HttpClient(httpHandler))
        {
            var result = await httpClient.PostAsJsonAsync<T>(url, model);
            if (result.IsSuccessStatusCode == false)
            {
                string message = await result.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
            else
            {
                return await result.Content.ReadAsAsync<U>();
            }
        }
    }
