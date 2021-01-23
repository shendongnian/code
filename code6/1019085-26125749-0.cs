    public class MmcHttpClient : HttpClient
    {
      public MmcHttpClient(HttpClientHandler handler, bool disposeHandler) : 
        base(App.Handler, disposeHandler)
      {
        BaseAddress = new Uri("http://localhost:65066/");
        DefaultRequestHeaders.Accept.Clear();
        DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      }
    }
