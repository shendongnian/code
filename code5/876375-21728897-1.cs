    class MyTestService:TestService.TestService
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = (HttpWebRequest) base.GetWebRequest(uri);
            //Setting KeepAlive to false
            webRequest.KeepAlive = false;
            return webRequest;
        }
    }
