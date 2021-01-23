    HttpClient client = new HttpClient();
    
    HttpRequestMessage request = new HttpRequestMessage();
    
    MultipartFormDataContent mfdc = new MultipartFormDataContent();
    mfdc.Add(new StringContent("Hell, World!"), "greeting");
    mfdc.Add(new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes("This is from a file"))), "Data", "File1.txt");
    
    HttpResponseMessage response = client.PostAsync(baseAddress + "/api/File", mfdc).Result;
