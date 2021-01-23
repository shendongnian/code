    HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
    filter.AllowAutoRedirect = false;
    HttpClient client = new HttpClient(filter);
    HttpResponseMessage response = await client.GetAsync(uri);
    Debug.WriteLine(response.Headers["Location"]); // Redirect URL is here.
