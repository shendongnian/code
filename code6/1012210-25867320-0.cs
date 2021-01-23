    private static ManualResetEvent evt = new ManualResetEvent(false);
    public static bool CheckForInternetConnection()
    {
      try
      {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
        request.UseDefaultCredentials = true;
        request.BeginGetResponse(new AsyncCallback(FinishRequest), request);
        evt.WaitOne();
        return request.HaveResponse;
      }
      catch
      {
        return false;
      }
    }
    private static void FinishRequest(IAsyncResult result)
    {
      HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
      evt.Set();
    }
