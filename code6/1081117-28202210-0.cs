				if (RememberMe ?? false)
				{
					var authCookie = new HttpCookie(Config.AuthorizationCookie);
					authCookie.Values.Add("ID", Crypto.EncryptStringAES(UserSession.Current.Account.ID.ToString(), Config.SharedSecret));
					authCookie.Expires = DateTime.Now.AddDays(30);
					AuthorizationCookie = authCookie;
				}
				Response.AppendCookie(AuthorizationCookie);
