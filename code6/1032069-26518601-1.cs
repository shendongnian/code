    var myMovieReadOnly = db.Movies.AsNoTracking().FirstOrDefault(m, m => m.Id = 1);
    
    var myMovie = db.Movies.FirstOrDefault(m, m => m.Id = 1);
    myMovie.Owner = new ApplicationUser { Id = 2 };
    
    db.SaveChanges();
