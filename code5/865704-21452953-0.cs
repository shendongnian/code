    void Main()
    {
    
    	GetIP("http://www.ip-adress.com/");
    	
    }
   
    async void GetIP(string url){
    	try{
    	"Looking Up".Dump("OK");
    	var x = await  GetResponse(url);
    	x.Dump();
    	}
    	catch(Exception e){
    		e.Dump("Problems:");
    	}
    }
    
    private static async Task<string> GetResponse(string url)
    {
        var httpClient = new HttpClient();
    
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
    
        var response = await httpClient.GetAsync(new Uri(url));
    
        response.EnsureSuccessStatusCode();
        using (var responseStream = await response.Content.ReadAsStreamAsync())
        //using (var decompressedStream = new System.IO.Compression.GZipStream(responseStream, CompressionMode.Decompress))
        using (var streamReader = new StreamReader(responseStream))
        {
            return streamReader.ReadToEnd();
        }
    }
