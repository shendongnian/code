    public class SmsData
    {
        public int Id { get; set; }
        public IEnumerable<Numbers> SmsNumbers { get; set; }
    }
    public class Numbers
    {
        public int Id { get; set; }
        public long Number { get; set; }
    }
