    [JsonConverter(typeof(MovieConverter))]
    public class Movie
    {
        public IDictionary<string, IList<MovieRating>> MovieInfo { get; set; }
    }
