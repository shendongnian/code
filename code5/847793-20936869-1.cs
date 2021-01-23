    var request = WebRequest.Create(url);
    string text;
     request.ContentType = "application/json; charset=utf-8";
    var response = (HttpWebResponse) request.GetResponse();
    using (var sr = new StreamReader(response.GetResponseStream()))
    {
        text = sr.ReadToEnd();
    }
