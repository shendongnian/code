    class SimilarArtist
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
        public int Similar_Artist_Id { get; set; }
        [NotMapped]
        public string ArtistName 
        {
           get 
           {
               return this.Artist.Name;            
           }
        }
    }
