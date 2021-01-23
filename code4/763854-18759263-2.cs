    private MovieBusiness _movieBusiness= (MovieBusiness )UnityHelper.BusinessResolve<Movie>();
    public object Get(MovieDTORequest request)
    {
        Movie movie = _movieBusiness.GetById(request.Id);
        MovieViewModel movieViewModel = MovieAdapter.ToViewModel(movie);
        return new MovieDTOResponse { Movie = movieViewModel };
    }
