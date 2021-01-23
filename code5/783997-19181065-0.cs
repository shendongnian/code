        //Disclaimer: I have no idea, whether this is an appropriate name. 
    	//It really depends on what you want to do with his class
    	class CustomNavigation
    	{
    		public string InputURL { get; private set; }
    		public string FFBaseURL { get; private set; }
    		public IEnumerable<string> ExcludeParams { get; private set; }
    		public string CurrentCategoryID { get; private set; }
    		public string NavigationParameters { get; private set; }
    
    		public CustomNavigation(string inputUrl, string excludeParam, string fBaseUrl, string currentCategoryID, string navigationParameters)
    		{
    			// various guard clauses here...
    
    			NavigationParameters = navigationParameters;
    			CurrentCategoryID = currentCategoryID;
    			FFBaseURL = fBaseUrl;
    			InputURL = inputUrl;
    
    			// Parse string here -> Makes your method simpler
    			ExcludeParams = new List<string>(excludeParam.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
    		}
    
    		//Example for encapsulating logic in param object
    		public void AddKeys(HttpContext currentContext)
    		{
    			var keys = currentContext.Request.QueryString.Keys
    						.Cast<string>()
    						.Where(key => !ExcludeParams.Contains(key));
    
    			foreach (var key in keys)
    				FFBaseURL += key + "=" + currentContext.Request[key] + "&";
    		}
    	}
