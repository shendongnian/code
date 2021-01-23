    string URI = "url here";
    string myParameters = string.Format("Parameter1={0}&Parameter2={1}", 
            HttpUtility.UrlEncode(var1), 
            HttpUtility.UrlEncode(var2));
    
    WebClient wc = new WebClient();
    wc.Encoding = Encoding.UTF8;
    wc.Headers["Content-type"] = "application/x-www-form-urlencoded";
    string HtmlResult = wc.UploadString(URI, myParameters);
