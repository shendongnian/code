    public static string CallWebService(string an, string xmlcommand)
    {
        String url = @"http://212.170.239.18/appservices/ws/FrontendService";
        try
        {
            String soapResult = null;
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(xmlcommand);
            HttpWebRequest webRequest = CreateWebRequest(_url, an);
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            using(HttpWebResponse response = webRequest.GetResponse())
            using (Stream s = webResponse.GetResponseStream())
            using (StreamReader rd = new StreamReader(gz))
            {
                if (an == "HotelValuedAvailRQ")
                {
                    soapResult = rd.ReadLine();
                }
                else
                {
                    soapResult = rd.ReadToEnd();
                }
                return soapResult;
            }
        }
        catch (WebException)
        { 
            return null;
        }
        catch (TimeoutException)
        {
            return null;
        }
    }
