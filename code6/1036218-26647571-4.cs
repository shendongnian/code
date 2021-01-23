    class Program
    {
        // Lazy backing fields
        private Lazy<SomeObject> obj1 = new Lazy<SomeObject>();
        private Lazy<SomeObject> obj2 = new Lazy<SomeObject>();
        private Lazy<SomeObject> obj3 = new Lazy<SomeObject>();
        private Lazy<SomeObject> obj4 = new Lazy<SomeObject>();
        private Lazy<SomeObject> obj5 = new Lazy<SomeObject>();
        // this way, obj1 only gets instanciated when needed
        public SomeObject Obj1 
        {
            get { return obj1.Value; }
        }
        // same for the other objects
  
        [...]
    }
