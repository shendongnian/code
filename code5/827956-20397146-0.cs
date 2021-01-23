    if (ModelState.IsValid)
    {
        db.AddToMovies(newMovie);
        db.SaveChanges();
    
        return View("Index", newMovie.Title);
    }
