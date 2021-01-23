    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(IDictionary<string, object> data)
        {
            // What to do if the map does not contain "Name" or "Age" ?
            // Right now: initialize to default value.
            Name = TryLookup<string>(data, "Name", null);
            Age = TryLookup<int>(data, "Age", default(int));
            // What to do if the map contains other items that do not
            // map to a member variable?
        }
        private static T TryLookup<T>(IDictionary<string, object> data, string key, T defaultValue)
        {
            return data.ContainsKey(key) ? (T)data[key] : defaultValue;
        }
    }
