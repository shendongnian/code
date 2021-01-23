    public class CookieAwareWebClient : WebClient
    {
      private static CookieContainer m_container = null;
      protected override WebRequest GetWebRequest(Uri address)
      {
        WebRequest request = base.GetWebRequest(address);
        HttpWebRequest webRequest = request as HttpWebRequest;
        if (m_container != null)
        {
            webRequest.CookieContainer = m_container;// will be called from the second time onwards
        }
        else
        {
          webRequest.CookieContainer = new CookieContainer();// First time
          m_container =  webRequest.CookieContainer; // Copy the container after the post is success
        }
        return request;
      }
    }
