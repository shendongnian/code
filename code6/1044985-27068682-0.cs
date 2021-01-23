		if (!HttpContext.Current.Request.IsAuthenticated)
		{
			var client = new FacebookClient(accessToken);
			if (client != null)
			{
				dynamic fbresult = client.Get("me");
				if (fbresult["id"] != null)
				{
					string fbid = fbresult["id"].ToString();
					ApplicationUser user = null;
					using (var context = new ApplicationDbContext())
					{
						user = context.Users.FirstOrDefault(u => u.UserName.ToString() == fbid);
					}
					if (user == null)
					{
						CreateUserAsync(fbid);
						return "user created. ";
					}
					else
					{
						HttpContext.Current.Session["user"] = "holy fuck";													
						return "user logged in. ";
					}
				}
			}
			return "ok";
		}
		else
		{
			return "already auth !";
		}
	}
