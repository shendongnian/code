    if (ModelState.IsValid)
    {
        db.AddToMovies(newMovie);
        db.SaveChanges();
        ViewData["MovieTitle"] = newMovie.Title;
    
        return View("Index");
    }
