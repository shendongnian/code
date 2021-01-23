    public class DataItem<T> {
        public string Title { get; set; }
        public string ID { get; set; }
        public Dictionary<string, T> Values { get; set; }
    }
