    // Start OWIN host 
    using (WebApp.Start<Startup>(url: baseAddress)) 
    { 
      // Create HttpCient and make a request to api/values 
      HttpClient client = new HttpClient(); 
      var response = client.GetAsync(baseAddress + "api/values").Result; 
    
      if (response != null)
      {
        Console.WriteLine("Information from service: {0}", response.Content.ReadAsStringAsync().Result);
      }
      else
      {
        Console.WriteLine("ERROR: Impossible to connect to service");
      }
    
      Console.WriteLine();
      Console.WriteLine("Press ENTER to stop the server and close app...");
      Console.ReadLine();
    } 
