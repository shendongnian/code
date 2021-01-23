    // simplified skeleton
    class MyClassName
    {
        private MyClassName() {}
        
        public Option<MyClassName> GetObject(string name)
        {
            return new MyClassName().ToOption();
        }
    
        public MyClassName DoJob() { return this; }
        public MyClassName Close() { return this; }
    }
    Option<MyClassName> obj = MyClassName.GetObject("Name").Select(x=>x.DoJob()).Select(x=>x.Close());
    
    if (obj.HasValue)
    {
        // can work with obj.Value
    }
    else
    {
        // somewhere was null
    }
