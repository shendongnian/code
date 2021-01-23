    public class RecordFile
    {
        public string Page { get; set; }
        public string Context { get; set; }
        public Dictionary<string, Record[]> Records { get; set; }
    }
    
    public class Record
    {
        public string Name { get; set; }
        public string Dob { get; set; }
    }
