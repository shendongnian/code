    public HttpResponseMessage ExecuteWithRetry(string url, string contentString)
    {
       HttpResponseMessage result = null;
       bool success = false;
       using (var client = new HttpClient())
       {
          do
          {
             result = client.PostAsync(url, new StringContent(contentString)).Result;
             success = result.IsSuccessStatusCode;
          }
          while (!success);
      }    
    
      return result;
    } 
