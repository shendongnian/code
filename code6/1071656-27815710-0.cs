    public class MyTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        [Ignore]
        public string ExtraData { get; set; } // This field will not be included in SQL
    }
