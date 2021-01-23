    public async Task<ActionResult> Favorites()
    {
            
      ViewBag.Content = await _favorites.GetGetFavoritesAsync(_currentUserId).ToListAsync();
      return View();
    }
