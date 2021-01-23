    var age = new TimeSpan(cacheTime, 0, 0);
	response.Headers.CacheControl = new CacheControlHeaderValue()
	{
		MaxAge = age,
		Public = false,
		NoCache = false,
		Private = true,
	};
	response.Content.Headers.Expires = DateTime.UtcNow.Add(age);
