    WebRequest request = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
    // Set the Network credentials
    request.Credentials = CredentialCache.DefaultCredentials;
    request.Method = "POST";
    // Create POST data and convert it to a byte array.
    string postData = "This is a test that posts this string to a Web server.";
    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    request.ContentType = "application/x-www-form-urlencoded";
    // Set the ContentLength property of the WebRequest.
    request.ContentLength = byteArray.Length;
    using (Stream dataStream = request.GetRequestStream())
    {
        // Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length);
    }
    using (WebResponse response = request.GetResponse())
    {
        // Display the status.
        Console.WriteLine(((HttpWebResponse)response).StatusDescription);
        // Get the stream containing content returned by the server.
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }
