    private async static Task<WebResponse> MakeRequestAsync(HttpWebRequest req)
    {
      Task<WebResponse> task = Task.Factory.FromAsync<WebResponse>(req.BeginGetResponse, req.EndGetResponse, null);
      try
      {
        return await task;
      }
      catch (WebException ex)
      {
        Debug.WriteLine("It's a web exception");
      }
      catch (Exception ex)
      {
        Debug.WriteLine("It's not a web exception.");
      }
    }
