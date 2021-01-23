     //Class Created to test the PostRequestMethod
    public class TestableRestClient : RestClient
    {
        public HttpWebRequest HttpWebRequestFake { get; set; }
        public string responseValue;
        protected override HttpWebRequest CreateHttpWebRequest(Uri url)
        {
            if (HttpWebRequestFake != null)
                return HttpWebRequestFake;
            return base.CreateHttpWebRequest(url);
        }
        protected override HttpWebResponse GetHttpWebResponse(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                responseValue = streamReader.ReadToEnd();
            }
            return base.GetHttpWebResponse(request);
        }
    }
    
