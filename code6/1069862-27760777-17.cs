    Anyway, you will need to filter the user information into a separate "bucket" to distinguish it from the song information.  The following class hierarchy and `JsonConverter` do the trick:
        public abstract class ResponseData
        {
            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }
        }
        public class SongData : ResponseData
        {
            [JsonProperty(PropertyName = "artist")]
            public string Artist { get; set; }
            [JsonProperty(PropertyName = "title")]
            public string SongName { get; set; }
            [JsonProperty(PropertyName = "url")]
            public string SongUri { get; set; }
            [JsonProperty(PropertyName = "duration")]
            public int Duration { get; set; }
            [JsonProperty(PropertyName = "owner_id")]
            public int OwnerId { get; set; }
            [JsonProperty(PropertyName = "lyrics_id")]
            public int LyricsId { get; set; }
            [JsonProperty(PropertyName = "genre_id")]
            public int GenreId { get; set; }
        }
        public class UserData : ResponseData
        {
            [JsonProperty(PropertyName = "photo")]
            public string Photo { get; set; }
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
            [JsonProperty(PropertyName = "name_gen")]
            public string NameGen { get; set; }
        }
        public class SongList
        {
            [JsonProperty(PropertyName="count")]
            public int Count { get; set; }
            [JsonIgnore]
            public List<SongData> Songs { get; set; }
            [JsonIgnore]
            public List<UserData> Users { get; set; }
            [JsonProperty(PropertyName = "items")]
            public ResponseData [] Items
            {
                get
                {
                    return (Users ?? Enumerable.Empty<UserData>()).Cast<ResponseData>().Concat((Songs ?? Enumerable.Empty<SongData>()).Cast<ResponseData>()).ToArray();
                }
                set
                {
                    Songs = (value ?? Enumerable.Empty<ResponseData>()).OfType<SongData>().ToList();
                    Users = (value ?? Enumerable.Empty<ResponseData>()).OfType<UserData>().ToList();
                }
            }
        }
        public class ResponseDataConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(ResponseData).IsAssignableFrom(objectType);
            }
            public override object ReadJson(JsonReader reader,
                Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject item = JObject.Load(reader);
                if (item["name"] != null)
                {
                    return item.ToObject<UserData>();
                }
                else
                {
                    return item.ToObject<SongData>();
                }
            }
            public override void WriteJson(JsonWriter writer,
                object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    Note that, for clarity, I renamed some of your classes and properties and moved nested classes out of their containers.
