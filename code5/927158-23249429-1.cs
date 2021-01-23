	public static List<string> SwearWords
	{
		get
		{
			List<string> items = HttpContext.Current.Cache["SwearWords"] as List<string>()
			if (items == null)
			{
				items = LoadThemFromDB();
				HttpContext.Current.Cache.Insert("SwearWords", 
					items, 
					null, 
					DateTime.Now.AddMinutes(10),
					Cache.NoSlidingExpiration);
			}
			return items;
		}
	}
