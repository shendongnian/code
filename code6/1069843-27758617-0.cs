    public class SongRoot
    {
         public SongResponse response {get;set;}
    }
    
    public class SongResponse {
         public  int count {get;set;}
         public List<SongData2> items {get;set;}
    }
   
    public class SongData2
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string SongName { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string SongUri { get; set; }
        public int Duration { get; set; }
        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }
        [JsonProperty(PropertyName = "lyrics_id")]
        public int LyricsId { get; set; }
        [JsonProperty(PropertyName = "genre_id")]
        public int GenreId { get; set; }
    }
