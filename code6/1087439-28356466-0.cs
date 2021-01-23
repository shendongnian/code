    string xml = String.Empty;
    // ... Fill in xml with your data
    NameValueCollection parameters = new NameValueCollection();
    parameters.Add("data", xml);
    byte[] response = null;
    string result = String.Empty;
    using (WebClient client = new WebClient())
    {
        response = client.UploadValues(url, parameters);
        result = Encoding.ASCII.GetString(response);
    }
