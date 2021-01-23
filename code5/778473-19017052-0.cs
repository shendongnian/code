    public MyViewModel()
    {
        UpcomingMovies = NotifyTaskCompletion.Create(LoadUpcomingMoviesAsync());
    }
    public INotifyTaskCompletion<List<MovieViewModel>> UpcomingMovies { get; private set; }
    private async Task<List<MovieViewModel>> LoadUpcomingMoviesAsync()
    {
        System.Diagnostics.Debug.WriteLine("UpcomingMovies - Begin");             
        var apiMovies = await _serviceRT.FindUpcomingMoviesList();
        var movies = apiMovies.Select(result => new MovieViewModel(result)).ToList();
        System.Diagnostics.Debug.WriteLine("UpcomingMovies - End");
        return movies;
    }
