    public class CreateArtistViewModel
    {
        public string ArtistName { get; set; }
        public int? Genres { get; set; } // if you provide chooser for user
        public string GenresName { get; set; } // if user can enter new genre
        public string GenresDecription { get; set; } // if user can enter new genre
    
        public IList<Genre> Genres { get; set; }
    }
