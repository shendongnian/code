    static class AuthenticationService
    {
      public static HttpClient CreateAuthenticatedSession(out HttpStatusCode statusCode)
      {
        var Client = new HttpClient
        {
          BaseAddress = new Uri(@" http://localhost:52310/ ")
        };
     
        var Result = Client.PostAsync("/Account/WebLogOn/",
          new FormUrlEncodedContent(
            new Dictionary<string, string>
            {
              {"UserName", "test"},
              {"Password", "1234"}
            }
          )
        ).Result;
     
        //Result.EnsureSuccessStatusCode();
        statusCode = Result.StatusCode;
     
        return Client;
      }
    }
