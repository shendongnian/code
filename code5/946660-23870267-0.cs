    using (WebClient client = new WebClient())
    {
        byte[] response = client.UploadValues("@"http://***/Token"", new NameValueCollection()
        {
            { "grant_type", "password" },
            { "username", "****@gmail.com" },
            { "password", "*****" }
        });
    }
