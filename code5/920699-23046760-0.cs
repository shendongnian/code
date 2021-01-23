    public static async Task<string> httpRequest(HttpWebRequest request)
    {
      Task.Factory.Startnew(() = > {
          var request = HttpWebRequest.Create("google.com")
          // Do more work
        }
    }
