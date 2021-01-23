    string url = "localhost:8080/MyService.svc/Submit/" + "helloWorld";
    string strResult = string.Empty;
    HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
    webrequest.Method = "GET";
    // set content type based on what your service is expecting
    webrequest.ContentType = "application/xml";
    //Gets the response
    WebResponse response = webrequest.GetResponse();
    //Writes the Response
    Stream responseStream = response.GetResponseStream();
    StreamReader sr = new StreamReader(responseStream);
    string s = sr.ReadToEnd();
    return s;
