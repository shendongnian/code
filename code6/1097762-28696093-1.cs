    public class ReplyRoot
    {
        public int count { get; set; }
        public int start_index { get; set; }
        public int end_index { get; set; }
        public int is_more { get; set; }
        public DataEntry[] data { get; set; }
    }
    public class DataEntry
    {
        public string token { get; set; }
        // [.. all properties ..]
    }
    var dto = JsonConvert.DeserializeObject<ReplyRoot>(jsonString);
