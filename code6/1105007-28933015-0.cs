    var xmlRequest = new XElement("CityStateLookupRequest",
        new XAttribute("USERID", "XXXXXXXXX"),
        new XElement("ZipCode",
            new XAttribute("ID", "0"),
            new XElement("Zip5", "43065")));
        
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://production.shippingapis.com/ShippingAPI.dll");        
    // parameters to post - other end expects API and XML parameters
    var postData = new List<KeyValuePair<string, string>>();
    postData.Add(new KeyValuePair<string, string>("API", "CityStateLookup"));
    postData.Add(new KeyValuePair<string, string>("XML", xmlRequest.ToString()));    
    
    // assemble the request content form encoded (reference System.Net.Http)
    HttpContent content = new FormUrlEncodedContent(postData);
    // indicate what we are posting in the request
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.ContentLength = content.Headers.ContentLength.Value;
    content.CopyToAsync(request.GetRequestStream()).Wait();                        
    // get response
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
    if (response.StatusCode == HttpStatusCode.OK)
    {
        // as an xml: deserialise into your own object or parse as you wish
        var responseXml = XDocument.Load(response.GetResponseStream());
        Console.WriteLine(responseXml.ToString());
    }
