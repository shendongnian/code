    public static Task<string> httpRequest(HttpWebRequest request)
    {
      return Task.Factory.Startnew(() = > {
          return HttpWebRequest.Create("google.com")
      }
    }
