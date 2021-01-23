    var ClientHandler = new HttpClientHandler();
    ClientHandler.UseCookies = true;
    ClientHandler.AllowAutoRedirect = true;
    ClientHandler.UseDefaultCredentials = true;
    ClientHandler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
    var Client = new HttpClient(ClientHandler);
    Client.DefaultRequestHeaders.Add("Accept", "text/html, application/xhtml+xml, */*");           
    Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
    var Response = await Client.GetAsync(RequestUri);
