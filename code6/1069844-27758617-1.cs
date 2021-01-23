    public class SongRoot
    {
         public SongResponse response {get;set;} // maps to { response: { ...  }}
    }
    public class SongResponse {
         public  int count {get;set;}  // maps to count: 529
         public List<SongData2> items {get;set;}  // maps to items: [{ ... }]
    }
   
    public class SongData2
    {
        public int Id { get; set; }  // maps to id: '34',
        public string Artist { get; set; } // maps to artist: 'Ocean Jet', 
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
