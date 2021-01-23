    public ActionResult Favorites()
    {
        // Create and start all tasks first.
    	var tFavs = new Task<List<Article>>(() =>
    		_favorites.GetFavorites(_currentUserId).ToList());
    	tFavs.Start();
        var task2 = new Task<SomeType>(() => new SomeType());
        task2.Start();
        // Wait for the results.
    	ViewBag.Content = tFavs.Result;
    	ViewBag.Content2 = task2.Result;
    	return View();
    }
