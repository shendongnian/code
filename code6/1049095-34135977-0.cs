    Task<string> response = client.GetAsync("https://www.bla.com/content").Result;
    if(!response.IsSuccessStatusCode)
    {
         if (resp.StatusCode == HttpStatusCode.Unauthorized)
         {
             do something...
         }
    }
    String urlContents = await response.Content.ReadAsStringAsync();
