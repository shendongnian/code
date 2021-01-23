    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class RootObject
    {
        public List<Genre> Genres { get; set; }
    }
