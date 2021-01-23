    using (var client = new WebClient())
    {
        // this is the string containing the soap message
        var data = File.ReadAllText("request.xml");
        // HTTP header. set it to the identical working example you monitor with fiddler from SOAP UI
        client.Headers.Add("Content-Type", "text/xml;charset=utf-8");
        // HTTP header. set it to the identical working example you monitor with fiddler from SOAP UI 
        client.Headers.Add("SOAPAction", "\"http://tempuri.org/ITestWcfService/TestMethod\"");
        // add/modify additional HTTP headers to make the request identical with what you get when calling from SOAP UI on a successful call 
        try
        {
            var response = client.UploadString("http://localhost:8080/TestWcfService", data);
        }
        catch (Exception e)
        {
            // handle exception                        
        }
    }
