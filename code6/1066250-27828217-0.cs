    public class Movie
    {
        public int Id { get; set; }
        public int ThumbnailId { get; set; }
        public Thumbnail Thumbnail { get; set; }
        
        public string Name { get; set; }
        public double Length { get; set; }
        public DateTime ReleaseDate { get; set; }
        //etc...
    }
    public class Thumbnail
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
    }
    public class MovieViewModel
    {
        private readonly Movie _movie;
        
        public MovieViewModel(Movie movie)
        {
            _movieModel = movieModel;
        }
        
        public byte[] Thumbnail { get { return _movie.Thumbnail.Data; } }
    }
