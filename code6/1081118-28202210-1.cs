			_account = UserSession.Current.Account;
			// check if there is currently an account in the session
			if(_account == null)
			{
				// check the user authorization cookie for a user id
				HttpCookie authCookie = HttpContext.Current.Request.Cookies[Config.AuthorizationCookie] ?? new HttpCookie(Config.AuthorizationCookie);
				if (authCookie.HasKeys && !String.IsNullOrEmpty(authCookie["ID"]))
				{
					// decrypt the user id for database lookup
					_userID = Crypto.DecryptStringAES(authCookie.Values["ID"], Config.SharedSecret);
				}
			}
