    using System.Net; 
    using System.Xml.Linq;
    
    public static class ClientHelper
    {
        public static string Post(string targetUrl, string action, string method, string key, string value)
        {
            var request = BuildEnvelope(method, key, value);
        using (var webClient = new WebClient())
        {
            webClient.Headers.Add("Accept-Header", "application/xml+");
            webClient.Headers.Add("Content-Type", "text/xml; charset=utf-8");
            webClient.Headers.Add("SOAPAction", action);
            var result = webClient.UploadString(targetUrl, "POST", request);
    
            return result;
        }
    }
    
    public static string BuildEnvelope(string method, string key, string value)
    {
        XNamespace s = "http://schemas.xmlsoap.org/soap/envelope/";
        XNamespace d = "d4p1";
        XNamespace tempUri = "http://tempuri.org/";
        XNamespace ns = "http://Foo.bar.car";
        XNamespace requestUri = "http://schemas.datacontract.org/2004/07/Foo.bar.car.Model.Policy";
        var xDoc = new XDocument(
                            new XElement(
                                s + "Envelope",
                                new XAttribute(XNamespace.Xmlns + "s", s),
                                new XElement(
                                    s + "Body",
                                    new XElement(
                                        ns + method,
                                        new XElement(requestUri + "request", 
                                            new XElement(tempUri + key, value))
                                    )
                                )
                            )
                        );
        // hack - finish XDoc construction later
        return xDoc.ToString().Replace("request xmlns=", "request xmlns:d4p1=").Replace(key, "d4p1:" + key);
    }
