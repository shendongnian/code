    try
    {
        byte[] formContentBytes = System.Text.ASCIIEncoding.UTF8.GetBytes("your xml request content");
        System.Net.WebRequest request = System.Net.WebRequest.Create(string.Format("https://merchantapi.apac.paywithpoli.com/MerchantAPIService.svc/Xml/transaction/initiate"));
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.ContentLength = formContentBytes.Length;
                var reqStream = request.GetRequestStream();
                reqStream.Write(formContentBytes, 0, formContentBytes.Length);
                var response = request.GetResponse();
                XmlSerializer serializer = new XmlSerializer(typeof(YOUR_XML_SERIALIZABLE_DATACONTRACT));
                YOUR_XML_SERIALIZABLE_DATACONTRACT responseData = serializer.Deserialize(response.GetResponseStream());
                reqStream.Close();
                response.Close();
    }
    catch(Exception ex){}
