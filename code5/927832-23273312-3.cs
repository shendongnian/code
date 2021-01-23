    var request = HttpWebRequest.Create(new Uri("http://xx.xx.xx.xx/mywebservice/")) as HttpWebRequest;
    request.Method = "GET";
    request.CookieContainer = cookieJar;
    request.BeginGetResponse(ar =>
    {
        HttpWebRequest req2 = (HttpWebRequest)ar.AsyncState;
        using (var response = (HttpWebResponse) req2.EndGetResponse(ar))
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    RootObject root = JsonConvert.DeserializeObject<RootObject>(reader.ReadToEnd());
                }
            }
                    
        }
    }, request);
