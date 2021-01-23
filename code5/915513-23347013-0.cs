    var request = HttpWebRequest.Create(new Uri("http://x.x.x.x/vertexweb10/webservice.svc/getallsymbols?AccountID=1122336675")) as HttpWebRequest;
    request.Method = "GET";
    request.CookieContainer = cookieJar;
    request.BeginGetResponse(ar =>
    {
        HttpWebRequest req2 = (HttpWebRequest)ar.AsyncState;
        using (var response = (HttpWebResponse)req2.EndGetResponse(ar))
        {
            using (Stream stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                   
                        
                    //the code you need
                }
            }
        }
    }, request);
   
