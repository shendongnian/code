    public class RecordFile
    {
        public string Page { get; set; }
        public string Context { get; set; }
        public Records Records { get; set; }
    }
    public class Records
    {
        public int RCount { get; set; }
        public IDictionary<string, List<Record>> RecordsDictionary { get; set; } 
    }
    public class Record
    {
        public string Name { get; set; }
        public string Dob { get; set; }
    }
