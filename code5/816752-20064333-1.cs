      // Create a New HttpClient object.
      HttpClient client = new HttpClient();
      HttpResponseMessage response = await client.GetAsync("http://localhost:27017/");
      response.EnsureSuccessStatusCode();
      string responseBody = await response.Content.ReadAsStringAsync();
      // Above three lines can be replaced with new helper method in following line 
      // string body = await client.GetStringAsync(uri);
      Console.WriteLine(responseBody); //HERE you can check for "MongoDB"
    }  
    catch(HttpRequestException e)
    {
      Console.WriteLine("\nException Caught!");	
      Console.WriteLine("Message :{0} ",e.Message);
    }
