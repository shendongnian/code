    var theWebRequest = HttpWebRequest.Create("http://YOURURL/YOURPAGE.aspx/Senddata");
    theWebRequest.Method = "POST";
    theWebRequest.ContentType = "application/json; charset=utf-8";
    theWebRequest.Headers.Add(HttpRequestHeader.Pragma, "no-cache");
    using (var writer = theWebRequest.GetRequestStream()) 
    {
        string send = null;
        send = "{\"value\":\"test\"}";
        var data = Encoding.ASCII.GetBytes(send);
        writer.Write(data, 0, data.Length);
    }
    var theWebResponse = (HttpWebResponse)theWebRequest.GetResponse();
    var theResponseStream = new StreamReader(theWebResponse.GetResponseStream());
    string result = theResponseStream.ReadToEnd();
    // Do something with the result
    TextBox1.Text = result;
