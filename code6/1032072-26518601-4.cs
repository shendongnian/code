    class Movie {
        public int OwnerId { get;set; }
        public ApplicationUser Owner { get;set; }
    }
    
    var myMovie = db.Movies.FirstOrDefault(m, m => m.Id = 1);
    myMovie.OwnerId = 2;
    db.SaveChanges();
