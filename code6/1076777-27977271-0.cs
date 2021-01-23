    private async Task<bool> RemoteFileExists(string url)
    {
       try
       {
          HttpWebRequest request = WebRequest.CreateHttp(url);
          request.Method = "HEAD";
          
          using(var response = (HttpWebResponse) await request.GetResponseAsync())
          {
              return (response.StatusCode == HttpStatusCode.OK);
          }
       }
       catch
       {
          return false;
       }
    }
