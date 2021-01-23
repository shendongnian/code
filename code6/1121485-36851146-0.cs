    public class ApiWebClient : WebClient {
      public DateTime? IfModifiedSince { get; set; }
    
      protected override WebRequest GetWebRequest(Uri address) {
        var webRequest = base.GetWebRequest(address);
        var httpWebRequest = webRequest as HttpWebRequest;
        if (httpWebRequest != null) {
          if (IfModifiedSince != null) {
            httpWebRequest.IfModifiedSince = IfModifiedSince.Value;
            IfModifiedSince = null;
          }
          // Handle other headers or properties here
        }
        return webRequest;
      }
    }
