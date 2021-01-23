    void Main()
    {	
    	const string Youtube 		= "youtube.com";
    	const string UriRegexPattern = @"v=([^\&]*)";
    	const string UriPath		 = "/watch";
    	const string UriQuery		 = "v=";
    	const string TestUri		 = "https://www.youtube.com/watch/HYE9H_ZUuOI";
    	const string ApiUri			 = "https://www.googleapis.com/youtube/v3/videos?id={0}&key=AIzaSyDWaA2OoArAjQTHqmN6r9XrpHYNkpKGyGw&part=snippet,contentDetails,statistics,status";
    	const int 	 TotalThreads    = 10;
    	ConcurrentQueue<string> UriQueue = new ConcurrentQueue<string>();
    	
    	for (int i = 0; i < 1000; i++)
    	{
    		UriQueue.Enqueue(TestUri);
    	}
    
    	Thread[] threads = new Thread[TotalThreads];
    	for (int i = 0; i < TotalThreads; i++)
    	{
    		int iCopy = i;
    		threads[iCopy] = new Thread(()=>
    		{
    			Stopwatch sw = new Stopwatch();
    			sw.Start();
    			
    			string uri;
    			
    			while (UriQueue.TryDequeue(out uri))
    			{
    				// Locate the final redirect Uri
    				Uri finalUri = Http.GetRedirectDestination(new Uri(uri));
    				Console.WriteLine ("THREAD[{0}] >>> Time taken locating redirect: {1}", iCopy, sw.Elapsed);
    				sw.Reset();
    				
    				// Ensure that the host is youtube, and the page contains a video
    				if (!finalUri.ContainsHost(Youtube) || !finalUri.ContainsPath(UriPath) || !finalUri.ContainsQuery(UriQuery)) return;
    				
    				// Extract the youtubeId using a regular expression.
    				string youtubeId = finalUri.ExtractQuery(UriRegexPattern);
    				
    				// The uri of api to query including the youtubeId extracted
    				string apiUri = string.Format(ApiUri, youtubeId);
    				
    				// Reset the stopwatch and query the api
    				sw.Start();
    				string json = Http.Get(new Uri(apiUri));
    				Console.WriteLine ("THREAD[{0}] >>> Time taken querying api: 	   {1}", iCopy, sw.Elapsed);
    				sw.Stop();
    				
    				// Also lets try not to get blacklisted by youtube
    				Thread.Sleep(500);
    			}
    		});
    		
    		threads[iCopy].Start();
    	}
    	
    	foreach(var thread in threads)
    	{	
    		thread.Join();
    	}
    }
    
    public static class Http
    {
    	public static Uri GetRedirectDestination(Uri uri, int retries = 0)
    	{
    		Uri redirectUri = null;
    		HttpWebRequest request             = (HttpWebRequest)WebRequest.Create(uri);
    		request.Method                     = "HEAD";
    		request.Accept                     = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
    		request.Headers["Accept-Language"] = "en-GB,en-US;q=0.8,en;q=0.6";
    		request.UserAgent 				   = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36";
    		request.AutomaticDecompression     = DecompressionMethods.GZip;
    		request.Timeout					   = 450;
    		try
    		{	        
    			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    			{
    				if (response.StatusCode == HttpStatusCode.Redirect || 
    					response.StatusCode == HttpStatusCode.RedirectKeepVerb || 
    					response.StatusCode == HttpStatusCode.RedirectMethod)
    				{
    					redirectUri = GetRedirectDestination(new Uri(response.Headers["Location"]));
    				}
    				
    				return response.ResponseUri;
    			}
    			
    		}
    		catch (WebException exception)
    		{
    			Console.WriteLine ("WebException Uri: {0}", uri);
    			Console.WriteLine (">> Message:  {0}", exception.Message);
    			Console.WriteLine (">> Status:   {0}", exception.Status);
    						
    			if (retries > 2)
    			{
    				throw;	
    			}
    			
    			retries += 1;
    			
    			return GetRedirectDestination(uri, retries);
    		}
    	}
    	
    	public static string Get(Uri uri, int retries = 0)
    	{
    		HttpWebRequest request             = (HttpWebRequest)WebRequest.Create(uri);
    		request.Accept                     = "application/json";
    		request.AutomaticDecompression     = DecompressionMethods.GZip;
    		
    		try
    		{	        
    			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    			using (Stream stream 			= response.GetResponseStream())
    			using (StreamReader reader 		= new StreamReader(stream))
    			{
    				return reader.ReadToEnd();	
    			}
    		}
    		catch (WebException exception)
    		{
    			// throw;
    			string exceptionResponse = string.Empty;
    			using (Stream stream = exception.Response.GetResponseStream())
    			
    			if (retries > 2)
    			{
    				throw;
    			}
    			
    			retries += 1;
    			
    			return Get(uri, retries); 
    		}
    	}
    
    }
    
    public static class Extensions
    {
    	public static bool IsNullOrWhiteSpace(this string text)
    	{
    		return string.IsNullOrWhiteSpace(text);
    	}
    
    	public static bool ContainsHost(this Uri uri, string host)
    	{
    		if (uri == null) 			   throw new ArgumentNullException("uri");
    		if (host.IsNullOrWhiteSpace()) throw new ArgumentNullException("host");
    			
    		return uri.Host.Contains(host);
    	}
    
    	public static bool ContainsPath(this Uri uri, string path)
    	{
    		if (uri == null) 						   throw new ArgumentNullException("uri");
    		if (path.IsNullOrWhiteSpace())			   throw new ArgumentNullException("path");
    		if (uri.PathAndQuery.IsNullOrWhiteSpace()) return false;
    	
    		return uri.PathAndQuery.ToLowerInvariant().Contains(path.ToLowerInvariant());
    	}
    	
    	public static bool ContainsQuery(this Uri uri, string query)
    	{	
    		if (uri == null) 					throw new ArgumentNullException("uri");
    		if (query.IsNullOrWhiteSpace()) 	throw new ArgumentNullException("query");
    		if (uri.Query.IsNullOrWhiteSpace()) return false;
    
    		return uri.Query.ToLowerInvariant().Contains(query.ToLowerInvariant());
    	}
    	
    	public static string ExtractQuery(this Uri uri, string regexPattern)
    	{
    		if (regexPattern.IsNullOrWhiteSpace()) throw new ArgumentNullException("regexPattern");
    		if (uri.Query.IsNullOrWhiteSpace())    return null;
    	
    		Match match = Regex.Match(uri.Query, regexPattern);
    		return match.Groups[1].Value;
    	}
    }
    
