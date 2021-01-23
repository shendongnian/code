        movie = (Movie)listBoxMovieExistingMovies.SelectedItem;
        movie.Actors.Clear();
        movie.Genres.Clear();
        db.Movies.Remove(movie);
        db.SaveChanges();
