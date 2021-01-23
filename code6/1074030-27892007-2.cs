    // simplified skeleton
    class MyClassName
    {
        private MyClassName() {}
        
        public MyClassName GetObject(string name)
        {
            return new MyClassName();
        }
    
        public MyClassName DoJob() { return this; }
        public MyClassName Close() { return this; }
    }
    Option<MyClassName> obj = MyClassName.GetObject("Name").ToOption().Select(x=>x.DoJob()).Select(x=>x.Close());
    
    if (obj.HasValue)
    {
        // can work with obj.Value
    }
    else
    {
        // somewhere was null
    }
