    public class Artist
    {
        public string ArtistId { get; set; }
        public string ArtistRev { get; set; }
    
        public string Name { get; set; }
        public Album[] Albums { get; set; }
    }
    
    public class Album
    {
        public string Name { get; set; }
        public int Tracks { get; set; }
    }
