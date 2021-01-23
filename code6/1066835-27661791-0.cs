    var root = JsonConvert.DeserializeObject<RootObject>(result);
---
    public class Record
    {
        public int StatusID { get; set; }
        public string Identifier { get; set; }
        public string Status { get; set; }
        public string StatusDate { get; set; }
        public string WorkedBy { get; set; }
        public string ContactedOn { get; set; }
        public string Email { get; set; }
    }
    public class RootObject
    {
        public List<Record> Record { get; set; }
    }
