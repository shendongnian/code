    if (!string.IsNullOrEmpty(jsonData))
    {
      var dataResult = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);
      
      if (dataResult != null && dataResult.response.sessionId != null)
      {
         // logged in
         // iterate and show bussiness list
      } else {
         Console.WriteLine("Login failed");
      }
    }
