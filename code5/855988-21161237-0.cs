    public class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        #region Navigation Properties
        public virtual ICollection<Album> Albums { get; set; }
        #endregion
    }
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
