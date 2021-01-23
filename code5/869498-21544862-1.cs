    void GetProductList()
    {
      HttpStatusCode statusCode;
     
      var httpClientSession
        = Helpers.AuthenticationService.CreateAuthenticatedSession(out statusCode);
     
      if (statusCode == HttpStatusCode.OK)
      {
        httpClientSession.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
     
        var result = httpClientSession.GetAsync("/api/product").Result;
     
        // Result.EnsureSuccessStatusCode();
        if (result.StatusCode == HttpStatusCode.OK)
        {
          string responseText = result.Content.ReadAsStringAsync().Result;
        }
        else
        {
          string errorText = string.Format("[{0}] - Cannot get the product list.", result.StatusCode);
        }
      }
      else
      {
        string errorText1 = "Authentication Failed";
      }
    }
