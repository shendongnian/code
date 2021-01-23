    try
    {
       string ResponseText = "";
    
        string WebServiceUrl = "http://192.168.1.3/META/services/ws.asmx"; 
        string WebMethodName = "FillXmlData"; 
    
        using (WebClient client = new WebClient())
        {
            client.Headers.Add("Content-Type", "text/xml; charset=utf-8");
                        var payload = string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
         <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
          <soap:Body>
            <{0} xmlns=""http://www.curs.kz/gdmx/services/"" />
          </soap:Body>
         </soap:Envelope>", WebMethodName);
    
            var data = Encoding.UTF8.GetBytes(payload);
            var result = client.UploadData(WebServiceUrl, data);
    
            ResponseText = Encoding.Default.GetString(result);
    
        }
        return ResponseText;
    }
    catch (WebException e)
    {
       string pageContent = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();
       Debug.WriteLine(pageContent);
       throw;
    }
