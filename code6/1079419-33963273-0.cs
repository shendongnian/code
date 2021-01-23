 
    /* 
    * NOTE:
    * It turns out that Silverlight provides HTTP handling in both the Browser and Client stack. 
    * By default Silverlight uses the Browser for HTTP handling. 
    * The only problem with this is that Browser HTTP Handling only supports GET and POST request methods.
    */
    WebRequest.RegisterPrefix("http://", WebRequestCreator.ClientHttp);
    WebRequest.RegisterPrefix("https://", WebRequestCreator.ClientHttp);
    var httpClient = new HttpClient();
    var byteArray = Encoding.UTF8.GetBytes("username:password");
    // Default headers will be sent with every request sent from this HttpClient instance.
    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
