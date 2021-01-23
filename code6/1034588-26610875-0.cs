    var url = Settings.Default.URL; //'Web service URL'
    var action = Settings.Default.SOAPAction; //the SOAP method/action name
    var soapEnvelopeXml = CreateSoapEnvelope();
    var soapRequest = CreateSoapRequest(url, action);
    InsertSoapEnvelopeIntoSoapRequest(soapEnvelopeXml, soapRequest);
    using (var stringWriter = new StringWriter())
    {
        using (var xmlWriter = XmlWriter.Create(stringWriter))
        {
            soapEnvelopeXml.WriteTo(xmlWriter);
            xmlWriter.Flush();
        }
    }
    // begin async call to web request.
    var asyncResult = soapRequest.BeginGetResponse(null, null);
    // suspend this thread until call is complete. You might want to
    // do something usefull here like update your UI.
    var success = asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
    if (!success) return null;
    // get the response from the completed web request.
    using (var webResponse = soapRequest.EndGetResponse(asyncResult))
    {
        string soapResult;
        var responseStream = webResponse.GetResponseStream();
        if (responseStream == null)
        {
            return null;
        }
        using (var reader = new StreamReader(responseStream))
        {
            soapResult = reader.ReadToEnd();
        }
        return soapResult;
    }
    private static HttpWebRequest CreateSoapRequest(string url, string action)
    {
        var webRequest = (HttpWebRequest)WebRequest.Create(url);
        webRequest.Headers.Add("SOAPAction", action);
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }
    private static XmlDocument CreateSoapEnvelope()
    {
        var soapEnvelope = new XmlDocument();
        soapEnvelope.LoadXml(Settings.Default.SOAPEnvelope); //the SOAP envelope to send
        return soapEnvelope;
    }
    private static void InsertSoapEnvelopeIntoSoapRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
    {
        using (Stream stream = webRequest.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }
    }
