    string url = "https://service.ringcentral.com/faxapi.asp";
    var data = new MultipartFormDataContent();
    data.Add(new StringContent("16501112222"), "username");
    data.Add(new StringContent("mypassword"), "password");
    data.Add(new StringContent("16501113333"), "recipient");
    data.Add(new StringContent("RingCentral FaxOut API using C#"), "coverpagetext");
    data.Add(new ByteArrayContent(File.ReadAllBytes("C:\\path\\to\\test.pdf", "attachment", "test.pdf");
    var client = new HttpClient();
    var response = client.PostAsync(new Uri(url), data).Result;
    if (response.IsSuccessStatusCode)
    {
        var responseContent = response.Content;
        var responseString = responseContent.ReadAsStringAsync().Result;
        Console.WriteLine(responseString);
    }
