    public class MyOuterDataContext
    {
        public MyInnerDataContext MyInnerDataContext { get; set; }
        
        public MyOuterDataContext()
        {
            MyInnerDataContext = new MyInnerDataContext();
        }
    }
    public class MyInnerDataContext
    {
        public string MyString { get { return "foo"; } }
    }
