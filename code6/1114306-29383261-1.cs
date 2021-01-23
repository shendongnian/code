    //using Newtonsoft.Json;
    //using Newtonsoft.Json.Linq;
    
    void Main()
    {	
	    ServicePointManager.DefaultConnectionLimit = int.MaxValue;
    	const string Youtube 		= "youtube.com";
    	const string UriRegexPattern = @"v=([^\&]*)";
    	const string UriPath		 = "/watch";
    	const string UriQuery		 = "v=";
    	const string TestUri		 = "https://www.youtube.com/watch/HYE9H_ZUuOI";
    	const string ApiUri			 = "https://www.googleapis.com/youtube/v3/videos?id={0}&key=AIzaSyDWaA2OoArAjQTHqmN6r9XrpHYNkpKGyGw&part=snippet,contentDetails,statistics,status";
    
    	// Start timing everything
    	Stopwatch sw = new Stopwatch();
    	sw.Start();
    	
    	// Locate the final redirect Uri
    	Uri uri = Http.GetRedirectDestination(new Uri(TestUri));
    	Console.WriteLine ("Time taken locating redirect: {0}", sw.Elapsed);
    	sw.Reset();
    	
    	// Ensure that the host is youtube, and the page contains a video
    	if (!uri.ContainsHost(Youtube) || !uri.ContainsPath(UriPath) || !uri.ContainsQuery(UriQuery)) return;
    	
    	// Extract the youtubeId using a regular expression.
    	string youtubeId = uri.ExtractQuery(UriRegexPattern);
    	
    	// The uri of api to query including the youtubeId extracted
    	string apiUri = string.Format(ApiUri, youtubeId);
    	
    	// Reset the stopwatch and query the api
    	sw.Start();
    	string json = Http.Get(new Uri(apiUri));
    	Console.WriteLine ("Time taken querying api: {0}", sw.Elapsed);
    	sw.Stop();
    	
    	// Deserialize the JSON response in to a C# object
    	// ### Important > You'll need to install the Newtonsoft.Json library
    	// ### pm> Install-Package Newtonsoft.Json
    	Metadata metadata = JsonConvert.DeserializeObject<Metadata>(json);
    	
    	// Serialize C# object into a JSON formatted string
    	Console.WriteLine (JsonConvert.SerializeObject(metadata, Newtonsoft.Json.Formatting.Indented));
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
    		request.Timeout					   = 450;
    		
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
    
    public class PageInfo
    {
    
       [JsonProperty("totalResults")]
       public int TotalResults { get; set; }
    
       [JsonProperty("resultsPerPage")]
       public int ResultsPerPage { get; set; }
    }
    
    public class Default
    {
    
       [JsonProperty("url")]
       public string Url { get; set; }
    
       [JsonProperty("width")]
       public int Width { get; set; }
    
       [JsonProperty("height")]
       public int Height { get; set; }
    }
    
    public class Medium
    {
    
       [JsonProperty("url")]
       public string Url { get; set; }
    
       [JsonProperty("width")]
       public int Width { get; set; }
    
       [JsonProperty("height")]
       public int Height { get; set; }
    }
    
    public class High
    {
    
       [JsonProperty("url")]
       public string Url { get; set; }
    
       [JsonProperty("width")]
       public int Width { get; set; }
    
       [JsonProperty("height")]
       public int Height { get; set; }
    }
    
    public class Thumbnails
    {
    
       [JsonProperty("default")]
       public Default Default { get; set; }
    
       [JsonProperty("medium")]
       public Medium Medium { get; set; }
    
       [JsonProperty("high")]
       public High High { get; set; }
    }
    
    public class Localized
    {
    
       [JsonProperty("title")]
       public string Title { get; set; }
    
       [JsonProperty("description")]
       public string Description { get; set; }
    }
    
    public class Snippet
    {
    
       [JsonProperty("publishedAt")]
       public string PublishedAt { get; set; }
    
       [JsonProperty("channelId")]
       public string ChannelId { get; set; }
    
       [JsonProperty("title")]
       public string Title { get; set; }
    
       [JsonProperty("description")]
       public string Description { get; set; }
    
       [JsonProperty("thumbnails")]
       public Thumbnails Thumbnails { get; set; }
    
       [JsonProperty("channelTitle")]
       public string ChannelTitle { get; set; }
    
       [JsonProperty("categoryId")]
       public string CategoryId { get; set; }
    
       [JsonProperty("liveBroadcastContent")]
       public string LiveBroadcastContent { get; set; }
    
       [JsonProperty("localized")]
       public Localized Localized { get; set; }
    }
    
    public class RegionRestriction
    {
    
       [JsonProperty("blocked")]
       public string[] Blocked { get; set; }
    }
    
    public class ContentDetails
    {
    
       [JsonProperty("duration")]
       public string Duration { get; set; }
    
       [JsonProperty("dimension")]
       public string Dimension { get; set; }
    
       [JsonProperty("definition")]
       public string Definition { get; set; }
    
       [JsonProperty("caption")]
       public string Caption { get; set; }
    
       [JsonProperty("licensedContent")]
       public bool LicensedContent { get; set; }
    
       [JsonProperty("regionRestriction")]
       public RegionRestriction RegionRestriction { get; set; }
    }
    
    public class Status
    {
    
       [JsonProperty("uploadStatus")]
       public string UploadStatus { get; set; }
    
       [JsonProperty("privacyStatus")]
       public string PrivacyStatus { get; set; }
    
       [JsonProperty("license")]
       public string License { get; set; }
    
       [JsonProperty("embeddable")]
       public bool Embeddable { get; set; }
    
       [JsonProperty("publicStatsViewable")]
       public bool PublicStatsViewable { get; set; }
    }
    
    public class Statistics
    {
    
       [JsonProperty("viewCount")]
       public string ViewCount { get; set; }
    
       [JsonProperty("likeCount")]
       public string LikeCount { get; set; }
    
       [JsonProperty("dislikeCount")]
       public string DislikeCount { get; set; }
    
       [JsonProperty("favoriteCount")]
       public string FavoriteCount { get; set; }
    
       [JsonProperty("commentCount")]
       public string CommentCount { get; set; }
    }
    
    public class Item
    {
    
       [JsonProperty("kind")]
       public string Kind { get; set; }
    
       [JsonProperty("etag")]
       public string Etag { get; set; }
    
       [JsonProperty("id")]
       public string Id { get; set; }
    
       [JsonProperty("snippet")]
       public Snippet Snippet { get; set; }
    
       [JsonProperty("contentDetails")]
       public ContentDetails ContentDetails { get; set; }
    
       [JsonProperty("status")]
       public Status Status { get; set; }
    
       [JsonProperty("statistics")]
       public Statistics Statistics { get; set; }
    }
    
    public class Metadata
    {
    
       [JsonProperty("kind")]
       public string Kind { get; set; }
    
       [JsonProperty("etag")]
       public string Etag { get; set; }
    
       [JsonProperty("pageInfo")]
       public PageInfo PageInfo { get; set; }
    
       [JsonProperty("items")]
       public Item[] Items { get; set; }
    }
