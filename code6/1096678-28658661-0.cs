    private static bool CheckWebApp(string uri) {
      try {
       var request = WebRequest.Create(uri);
       var response = (HttpWebResponse)request.GetResponse();
       return (response.StatusCode == HttpStatusCode.OK);
      }
      catch {
       return false;
      }
     }
