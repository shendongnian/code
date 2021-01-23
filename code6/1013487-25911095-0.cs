    class MovieConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Movie);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {            
            var movie = new Movie(){
                MovieInfo = new Dictionary<string,IList<MovieRating>>()
            };
            while (reader.Read() && reader.Value != null)
            {                
                var name = (string)reader.Value;
                reader.Read();
                var ratings = ((JArray)serializer.Deserialize(reader)).Values<string>("rating");
                movie.MovieInfo.Add(name, ratings.Select(r => new MovieRating(){ Rating = r}).ToList());
            }
            return movie;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
