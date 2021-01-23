            [AcceptVerbs("GET", "POST")]
    		public ServiceResult Login(JObject args)
    		{
    			var retVal = new ServiceResult {Success = false};
    			JToken tokenValue;
    			var email = string.Empty;
    			var password = string.Empty;
    
    			if (args.TryGetValue("email", out tokenValue))
    			{
    				email = args.Value<string>("email");
    			}
    
    			if (args.TryGetValue("password", out tokenValue))
    			{
    				password = args.Value<string>("password");
    			}
    			
    			var user = Services.Users.GetByEmail(email, true);
    
    			if (null != user || null != user.Id)
    			{
    				return Services.Authentication.AuthenticateSignIn(user, password, true);
    
    			}
    	
    			retVal.Data = tokenValue;
    			return retVal;
    		}
