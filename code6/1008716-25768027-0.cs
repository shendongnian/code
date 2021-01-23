    public interface IMovieService
    {
        int Create(MovieData movie);
        List<MovieData> GetAllData();
        MovieData GetDataById(int id);
        void Update(MovieData movie);
    }
