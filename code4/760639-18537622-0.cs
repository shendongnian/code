	if (Request.Cookies["userInfo"] != null)
	{
		string userSettings, lastVisit ;
		if (Request.Cookies["userInfo"]["userName"] != null)
		{
			userSettings = Request.Cookies["userInfo"]["userName"].ToString(); 
		}
		if (Request.Cookies["userInfo"]["lastVisit"] != null)
		{
			lastVisit = Request.Cookies["userInfo"]["lastVisit"].ToString(); 
		}
	}
