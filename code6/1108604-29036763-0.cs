    var infoQuery =
                        (from MovieGen in dbContext.GenreMovies
                        select new { MovieGen.RowID, Genre=MovieGen.MovieGenre})
                        .Union
                            (from MusicGen in dbContext.GenreMusics
                            select new {MusicGen.RowID, Genre=MusicGen.MusicGenre).Union(from PodcastGen in dbContext.GenrePodcasts select new {PodcastGen.RowID, Genre=PodcastGen.PodcastGenre).ToList();
    
    
            GridSortSearch.DataTextField = "Genre";
            GridSortSearch.DataSource = infoQuery;
            GridSortSearch.DataBind();
