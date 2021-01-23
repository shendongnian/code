    using (var _db = new YourDbContext())
    {
        var movies = _db.Movies;
        var movieReviews = _db.MovieReviews;
    
        var results = movies.Join(movieReviews, 
            m => m.Id,
            mr => mr.MovieId,
            (m, mr) => new { MovieName = m.Name, ReviewerName = mr.ReviewerName }).ToList();
    }
