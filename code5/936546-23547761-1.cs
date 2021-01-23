    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:9095");
    HttpRequestMessage request = new HttpRequestMessage();
    
    MultipartFormDataContent mfdc = new MultipartFormDataContent();
    mfdc.Add(new StringContent("Hell, World!"), "greeting");
    mfdc.Add(new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes("This is from a file"))), name: "Data", fileName: "File1.txt");
    
    HttpResponseMessage response = client.PostAsync("/api/File", mfdc).Result;
