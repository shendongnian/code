    Uri uri = new Uri(
        "https://http2.cloudapp.net/?status=302&name=Location&value=http%3a%2f%2fkiewic.com");
    HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
    // Only needed to be able to connect to test server.
    filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
    // Turn off auto-redirections.
    filter.AllowAutoRedirect = false;
    HttpClient client = new HttpClient(filter);
    HttpStringContent content = new HttpStringContent("blah");
    HttpResponseMessage response = await client.PostAsync(uri, content);
    // Redirect URL is here.
    Debug.WriteLine(response.Headers["Location"]);
