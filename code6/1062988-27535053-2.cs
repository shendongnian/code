    class MyEntity
    {
        public IEnumerable<string> Data { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IList<MyEntity> entities = new MyEntity[] {
                new MyEntity { Data = new [] { "1", "2" }.Where(x => x != string.Empty) },
                new MyEntity { Data = new [] { "A", "B" }.AsQueryable().Where(x => x != string.Empty) },
                new MyEntity { Data = new List<string> { "A", "B" } },
            };
            string data = JsonConvert.SerializeObject(entities, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            data = Regex.Replace(data, "\"\\$type\":\\s+\"System.Linq.Enumerable\\+WhereArrayIterator(.+?), System.Core\",", "\"$type\": \"System.Collections.Generic.List$1, mscorlib\",", RegexOptions.Singleline);
            var j = JsonConvert.DeserializeObject<IEnumerable<MyEntity>>(data, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        }
    }
