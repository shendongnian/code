    public class SomeClass
    {
        public SomeClass() { }
    
        int someInt = 10;
    
        public string SomeString { get; set; }
        public int SomeInt
        {
            get { return someInt; }
            set { someInt = value; }
        }
    }
