    private async Task<string> MakeAsyncRequestAsync(string url, string contentType)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.ContentType = contentType;
      request.Method = WebRequestMethods.Http.Get;
      request.Timeout = 20000;
      request.Proxy = null;
      WebResponse response = await request.GetResponseAsync();
      return ReadStreamFromResponse(response);
    }
