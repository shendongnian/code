    public class Playlist
    {
        public int ID {get;set;}
        public string PlaylistName { get; set; }
        public int UserId { get; set; }
        public List<int> Tracks { get; set; }
    }
