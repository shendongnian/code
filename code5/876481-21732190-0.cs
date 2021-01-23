    string result = "";
    using (var client = new WebClient())
    {
        result = client.UploadString(url, "POST", json);
    }
    Console.WriteLine(result);
