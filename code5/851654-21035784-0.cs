    public partial class Title
    {
        public virtual string Genre { get; set; }
        public virtual ICollection<Genre> GenreInfo { get; set; }
    }
    public partial class Genre
    {
        public int GenreID { get; set; }
        public string sGenre { get; set; } // This contains unique genre code.
        public string Keywords { get; set; }
    }
