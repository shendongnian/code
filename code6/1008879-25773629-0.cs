    	public class TwitterAuthTool : IDisposable {
		private const string BASE_AUTH_URL = "https://api.twitter.com/oauth2/token";
		private const string BASE_SEARCH_URL = "https://api.twitter.com/1.1/search/tweets.json";
		private const string BASE_INVALIDATE_URL = "https://api.twitter.com/oauth2/invalidate_token";
		private AccessToken Credentials;
		private string BearerTokenCredentials;
		public TwitterAuthTool( string p_ConsumerKey, string p_ConsumerSecret ) {
			BearerTokenCredentials =
				Convert.ToBase64String(
					Encoding.ASCII.GetBytes(
						string.Format( "{0}:{1}",
							Uri.EscapeUriString( p_ConsumerKey ),
							Uri.EscapeUriString( p_ConsumerSecret ) ) ) );
			HttpWebRequest _Request = HttpWebRequest.Create( BASE_AUTH_URL ) as HttpWebRequest;
			_Request.KeepAlive = false;
			_Request.Method = "POST";
			_Request.Headers.Add( "Authorization", string.Format( "Basic {0}", BearerTokenCredentials ) );
			_Request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
			byte[] _Content = Encoding.ASCII.GetBytes( "grant_type=client_credentials" );
			using( Stream _Stream = _Request.GetRequestStream() )
				_Stream.Write( _Content, 0, _Content.Length );
			HttpWebResponse _Response = _Request.GetResponse() as HttpWebResponse;
			DataContractJsonSerializer _AccessTokenJsonSerializer = new DataContractJsonSerializer( typeof( AccessToken ) );
			Credentials = (AccessToken)_AccessTokenJsonSerializer.ReadObject( _Response.GetResponseStream() );
		}
		public List<Tweet> GetLatest( string p_Query, int p_Count = 100 ) {
			TwitterResults _TwitterResults;
			List<Tweet> _ReturnValue = new List<Tweet>();
			DataContractJsonSerializer _JsonSerializer = new DataContractJsonSerializer( typeof( TwitterResults ) );
			HttpWebRequest _Request = WebRequest.Create( string.Format( "{0}?q={1}&result_type=recent&count={2}", BASE_SEARCH_URL, p_Query, p_Count ) ) as HttpWebRequest;
			_Request.Headers.Add( "Authorization", string.Format( "Bearer {0}", Credentials.access_token ) );
			_Request.KeepAlive = false;
			_Request.Method = "GET";
			HttpWebResponse _Response = _Request.GetResponse() as HttpWebResponse;
			_TwitterResults = (TwitterResults)_JsonSerializer.ReadObject( _Response.GetResponseStream() );
			_ReturnValue.AddRange( _TwitterResults.statuses );
			while( !string.IsNullOrWhiteSpace( _TwitterResults.search_metadata.next_results ) ) {
				_Request = WebRequest.Create( string.Format( "{0}{1}", BASE_SEARCH_URL, _TwitterResults.search_metadata.next_results ) ) as HttpWebRequest;
				_Request.Headers.Add( "Authorization", string.Format( "Bearer {0}", Credentials.access_token ) );
				_Request.KeepAlive = false;
				_Request.Method = "GET";
				_Response = _Request.GetResponse() as HttpWebResponse;
				_TwitterResults = (TwitterResults)_JsonSerializer.ReadObject( _Response.GetResponseStream() );
				_ReturnValue.AddRange( _TwitterResults.statuses );
			}
			return _ReturnValue;
		}
		public List<Tweet> GetLatestSince( string p_Query, long p_SinceId, int p_Count = 100 ) {
			TwitterResults _TwitterResults;
			List<Tweet> _ReturnValue = new List<Tweet>();
			DataContractJsonSerializer _JsonSerializer = new DataContractJsonSerializer( typeof( TwitterResults ) );
			HttpWebRequest _Request = WebRequest.Create( string.Format( "{0}?q={1}&result_type=recent&count={2}&since_id={3}", BASE_SEARCH_URL, p_Query, p_Count, p_SinceId ) ) as HttpWebRequest;
			_Request.Headers.Add( "Authorization", string.Format( "Bearer {0}", Credentials.access_token ) );
			_Request.KeepAlive = false;
			_Request.Method = "GET";
			HttpWebResponse _Response = _Request.GetResponse() as HttpWebResponse;
			_TwitterResults = (TwitterResults)_JsonSerializer.ReadObject( _Response.GetResponseStream() );
			_ReturnValue.AddRange( _TwitterResults.statuses );
			while( !string.IsNullOrWhiteSpace( _TwitterResults.search_metadata.next_results ) ) {
				_Request = WebRequest.Create( string.Format( "{0}{1}", BASE_SEARCH_URL, _TwitterResults.search_metadata.next_results ) ) as HttpWebRequest;
				_Request.Headers.Add( "Authorization", string.Format( "Bearer {0}", Credentials.access_token ) );
				_Request.KeepAlive = false;
				_Request.Method = "GET";
				_Response = _Request.GetResponse() as HttpWebResponse;
				_TwitterResults = (TwitterResults)_JsonSerializer.ReadObject( _Response.GetResponseStream() );
				_ReturnValue.AddRange( _TwitterResults.statuses );
			}
			return _ReturnValue;
		}
		public void Dispose() {
			HttpWebRequest _Request = WebRequest.Create( BASE_INVALIDATE_URL ) as HttpWebRequest;
			_Request.KeepAlive = false;
			_Request.Method = "POST";
			_Request.Headers.Add( "Authorization", string.Format( "Basic {0}", BearerTokenCredentials ) );
			_Request.ContentType = "application/x-www-form-urlencoded";
			byte[] _Content = Encoding.ASCII.GetBytes( string.Format( "access_token={0}", Credentials.access_token ) );
			using( Stream _Stream = _Request.GetRequestStream() )
				_Stream.Write( _Content, 0, _Content.Length );
			try {
				_Request.GetResponse();
			} catch {
				// The bearer token will time out if this fails.
			}
		}
	}
