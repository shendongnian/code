    HttpResponseMessage response = await client.GetAsync("https://www.bla.com/content");
    if(!response.IsSuccessStatusCode)
    {
         if (response.StatusCode == HttpStatusCode.Unauthorized)
         {
             do something...
         }
    }
    String urlContents = await response.Content.ReadAsStringAsync();
