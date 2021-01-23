        public class Value
        {
            public string key { get; set; }
            public string value { get; set; } // Type changed from "object" to "string".
        }
        public class Result
        {
            public int resultnumber { get; set; }
            public List<Value> values { get; set; }
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
    And then
            var root = JsonConvert.DeserializeObject<RootObject>(json);
            var books = root.searchresult.results.Select(result => new Book { Name = result.values.Find(v => v.key == "name").value, BookId = result.values.Find(v => v.key == "bookid").value });
