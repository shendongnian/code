    var p = _theaterMovieShowTimeService.GetAllTheaterMovieShowTime()
        .GroupBy(x => x.TheaterMovieDetailID)
        .Select(x => new TheaterMovieShowTimeSummaryViewModel
        {
            TheaterName = x.FirstOrDefault().TheaterMovieDetails.Theater.TheaterName,
            MovieName = x.FirstOrDefault().TheaterMovieDetails.Movie.MovieName,
            NoOfShows= x.Count()  // get the no of rows here
        });
