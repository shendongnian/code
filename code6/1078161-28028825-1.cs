    using (HttpClient client = new HttpClient())
    {
                        
      client.BaseAddress = new Uri("http://yourapisite.com"); // Not whole link, just host
    
      var url = "link after your host url";
    
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
      HttpResponseMessage response = await client.GetAsync(url);
    
      if (response.IsSuccessStatusCode)
      {
         var data = response.Content.ReadAsStringAsync();
         YourClass responsedata = JsonConvert.DeserializeObject<YourClass>(data.Result.ToString());
    
    
    
      }
    
