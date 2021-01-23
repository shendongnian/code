        string url = "http://localhost:8080/test.php";
        string str = "test";
        WebClient webClient = new WebClient();            
        NameValueCollection formData = new NameValueCollection();          
        formData["message"] = str;
        byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);          
        string responsefromserver = Encoding.UTF8.GetString(responseBytes); 
    Console.WriteLine(responsefromserver);          
        webClient.Dispose();
