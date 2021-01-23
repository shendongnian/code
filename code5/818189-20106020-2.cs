     public async Task<T> DoMyWork<T>(T obj)
     {
       using(var client = new HttpClient())
       {
            var response = await client.GetAsync(uri);
            return await response.Content.ReadAsAsync<T>();
       }
     }
