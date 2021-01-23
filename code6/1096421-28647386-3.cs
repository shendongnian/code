        internal class BookConverter : JsonConverter
        {
            public override bool CanWrite
            {
                get
                {
                    return false;
                }
            }
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(Book);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var values = serializer.Deserialize<List<KeyValuePair<string, string>>>(reader);
                if (values == null)
                    return existingValue;
                var book = existingValue as Book;
                if (book == null)
                    book = new Book();
                // The following throws an exception on missing keys.  You could handle this differently if you prefer.
                book.BookId = values.Find(v => v.Key == "bookid").Value;
                book.Name = values.Find(v => v.Key == "bookid").Value;
                return book;
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
        public class Result
        {
            public int resultnumber { get; set; }
            [JsonProperty("values")] 
            [JsonConverter(typeof(BookConverter))]
            public Book Book { get; set; }
        }
        public class Searchresult
        {
            public int resultscount { get; set; }
            public List<Result> results { get; set; }
        }
        public class RootObject
        {
            public Searchresult searchresult { get; set; }
        }
    and then
            var root = JsonConvert.DeserializeObject<RootObject>(json);
            var books = root.searchresult.results.Select(result => result.Book);
    Here I only implemented `ReadJson` as your question only asks about deserialization .  You could implement `WriteJson` similarly if required.
