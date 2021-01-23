    public class SampleDetailValues // this is the detail entity
    {
       public int Id { get; set; }
    }
    public class SampleParameter // this is a class that i will use for the business logic
    {
        public string Name { get; set; }
        public string SampleDetailIds {get;Set;} // you should convert array to string and back...eg join/split
        public SampleDetailValues[] SampleDetail { get; set; } // ef should ignore this type as it is invalid on Db.
        public double { get; set; }
    }
