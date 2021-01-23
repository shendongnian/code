    public class Movies
    {
        public List<Movie> List { get; set; }
        public Movies()
        {
            List = new List<Movie>();
        }
        public void Add(Movie newMovie)
        {
            newMovie.Id = List.Count > 0 ? List.Max(x => x.Id)+1 : 1;
            List.Add(newMovie);
        }
        public void Remove(Movie oldMovie)
        {
            List.Remove(oldMovie);
            List.ForEach((x) => { if (x.Id > oldMovie.Id) x.Id = x.Id - 1; });
        }
    }
