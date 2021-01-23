    string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
        .GetBytes(userName + ":" + userPassword));
    HttpRequestMessage mess = new HttpRequestMessage(HttpMethod.Get, 
        new Uri("https://ssl.mywebsite.nl/"));
    mess.Headers.Add("Authorization", "Basic " + encoded);
    webView.NavigateWithHttpRequestMessage(mess);
