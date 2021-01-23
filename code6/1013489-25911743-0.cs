    class MovieList
    {
        [JsonProperty("movies")]
        public Movie[] Movies { get; set; }
    }
    
    class Movie : Dictionary<string, MovieRating[]>
    {
    }
    
    class MovieRating
    {
        [JsonProperty("rating")]
        public string Rating { get; set; }
    }
