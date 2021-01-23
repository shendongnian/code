    public class MyWebClient : WebClient {
        protected override WebRequest GetWebRequest(Uri uri) {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 30000; // the only way to set the timeout is through overriding the base class.
            return w;
        }
    }
