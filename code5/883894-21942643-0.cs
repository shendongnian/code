    public class Genre
    {
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
    public class Album
    {
        public string Genre { get; set; }
        public string Name { get; set; }
    }
