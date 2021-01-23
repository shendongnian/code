    public class CustomWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var newUrl = address.OriginalString;
            if (newUrl.Contains("?"))
                newUrl += "&";
            else
                newUrl += "?";
            newUrl += "MyCustomParam=value";
            
            return base.GetWebRequest(new Uri(newUrl));
        }
    }
