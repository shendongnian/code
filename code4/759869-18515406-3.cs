    [DelimitedRecord(",")]
    public class SampleType
    {
        public string Field1;
        public int Field2;
    
        [FieldConverter(typeof(MyCustomConverter))]
        public IEnumerable<ChildClass>  Collection { get; set; }
    }
