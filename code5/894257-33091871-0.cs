    HttpClient httpClient = new HttpClient();   
    
    //specify to use TLS 1.2 as default connection
    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
    
    httpClient.BaseAddress = new Uri("https://foobar.com/");
    httpClient.DefaultRequestHeaders.Accept.Clear();
    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        
    var task = httpClient.PostAsXmlAsync<DeviceRequest>("api/SaveData", request);
