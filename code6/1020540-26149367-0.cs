    public async Task<ActionResult> Favorites()
    {
            
      ViewBag.Content = await _favorites.GetFavorites(_currentUserId).ToListAsync();
      return View();
    }
