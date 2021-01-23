    Uri RequestUri = new Uri("subcard.subway.co.uk/de_cardholder/servlet/SPLoginServlet HTTP/1.1?language=de&userID=ID&password=PASSWORD&transIdentType=1&programID=6", UriKind.Absolute);
    string PostData = "";
    WebRequest webRequest;
    webRequest = WebRequest.Create(RequestUri);
    webRequest.Method = "POST";
    webRequest.ContentType = "text/xml";
            
    HttpWebResponse response;
    string Response;
    using (response = (HttpWebResponse)await webRequest.GetResponseAsync()) ;
    using (Stream streamResponse = response.GetResponseStream())
    using (StreamReader streamReader = new StreamReader(streamResponse))
    {
        Response = await streamReader.ReadToEndAsync();
    }
    if(Response != null)
    {
        //data should be available in Response
    }
