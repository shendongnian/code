    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request.GetType() == typeof(HttpWebRequest)){
                ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.17 Safari/537.36";
            }
            return request;
        }
    }
    using(var wc = new MyWebClient()){
        var response = wc.DownloadString(url);
        //do stuff with response
    }
