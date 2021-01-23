    public class MyObject
    {
        public MyObject()
        {
            this.Values = new Values();
        }
    
        public int Code { get; set; }
        public string Message { get; set; }
        public Values Values { get; set; }
    }
    
    public class Values
    {
        public string Name { get; set; }
    }
