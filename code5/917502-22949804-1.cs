    public IQueryable<MovieData> Get()
    {
        if (MovieRepository != null)
        {
            return MovieRepository;
        }
        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFount));
    }
