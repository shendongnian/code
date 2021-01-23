    [Serializable()]
    public class SomeClass
    {
        public SomeClass() {//init}
        public string SomeString { get; set; }
    
        [OptionalField(VersionAdded = 2)]
        public int SomeInt { get; set; }
 
        [OnDeserialized()]
        private void SetValuesOnDeserialized(StreamingContext context)
        {
            this.SomeInt = 10;
        }
    }
