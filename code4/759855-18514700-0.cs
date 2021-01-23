    public class Root
    {
        public Dictionary<string, Data> Data { get; set; }
        public bool Success { get; set; }
    }
    
    public class Data
    {
        public string Path { get; set; }
        public int MinVersion { get; set; }
        public int MaxVersion { get; set; }
    }
