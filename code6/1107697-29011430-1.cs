     using (var client = new HttpClient())
     {
        client.DefaultRequestHeaders.Accept.Clear();
        client.Timeout = this.Timeout; // (500ms)
        try
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(EndPoint, PostData);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new CustomException()
            }
        }
        catch (TaskCanceledException)
        {
            // request did not complete in 500ms.
            return null; // or something else to indicate no data, move on
        }
     } 
