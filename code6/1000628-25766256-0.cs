    	void LoginByGoogle ()
    	{
    		var auth = new OAuth2Authenticator (
    			clientId: “………googleusercontent.com", 
    			scope: "https://www.googleapis.com/auth/userinfo.email", 
    			authorizeUrl: new Uri ("https://accounts.google.com/o/oauth2/auth"),
    			redirectUrl: new Uri ("http://........./........aspx"), 
    			getUsernameAsync: null);  
    
    		string access_token;
    		auth.Completed += (sender , e ) =>
    		{  
    			Console.WriteLine ( e.IsAuthenticated );
    			e.Account.Properties.TryGetValue ( "access_token" , out access_token ); 
    			//get user full information
    			getInfo();
    
    		} ; 
    		var intent = auth.GetUI (this);
    		StartActivity (intent);
    	}
    
    
    
    	async void getInfo()
    	{   
    		//do RESP request,by appending token
    		string userInfo = await GetDataFromGoogle (access_token ); 
    		Console.WriteLine (  userInfo);
    		if ( userInfo != "Exception" )
    		{
    			//Deserialize  to objet
    			GoogleUserInfo googleIngo = JsonConvert.DeserializeObject<GoogleInfo> ( userInfo );  
    		}
    		else
    		{  
    			console.writeline(“exception”);
    		}
    	}
    
    	async   Task<string> GetDataFromGoogle(string accessTokenValue)
    	{    
    		string  strURL =  	"https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + accessTokenValue + “”;	 
    		WebClient client = new WebClient (); 
    		try
    		{
    			strResult=await client.DownloadStringTaskAsync (new Uri(strURL));
    			Console.WriteLine("downloaded");
    		}
    		catch
    		{
    			strResult="Exception";
    		}
    		finally
    		{
    			client.Dispose ();
    			client = null; 
    		}
    		return strResult;
    	}
    
    	public class GoogleUserInfo
    	{
    		public string id { get; set; }
    		public string email { get; set; }
    		public bool verified_email { get; set; }
    		public string name { get; set; }
    		public string given_name { get; set; }
    		public string family_name { get; set; }
    		public string link { get; set; }
    		public string picture { get; set; }
    		public string gender { get; set; }
    	}
     
