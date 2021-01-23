    [DelimitedRecord(",")]
    public class SampleType
    {
        public string Field1;
        public int Field2;
    
        public IEnumerable<ChildClass>  Collection { get; set; }
        public string CollectionValues
        {
           get
           {
              string.Join("|", this.Collection.Select(c => c.Value));
           }
        }
    }
