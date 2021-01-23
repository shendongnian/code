    HttpClient client = new HttpClient();
    try	
    {
      // Make an asynchronous call to get the web page
      HttpResponseMessage response = await client.GetAsync("http://www.msn.com/");
      response.EnsureSuccessStatusCode();
      string responseBody = await response.Content.ReadAsStringAsync();
      
      // Do something more useful with the returned page
      Console.WriteLine(responseBody);
    }  
    catch(HttpRequestException e)
    {
      Console.WriteLine("\nException Caught!");	
      Console.WriteLine("Message :{0} ", e.Message);
    }
    // Need to call dispose on the HttpClient object when we 
    // are done using it, so the app doesn't leak resources
    client.Dispose(true);
