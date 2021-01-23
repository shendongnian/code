    class Program
    {
        // backing fields
        private SomeObject obj1;
        private SomeObject obj2;
        private SomeObject obj3;
        private SomeObject obj4;
        private SomeObject obj5;
        // this way, obj1 only gets instanciated when needed
        public SomeObject Obj1 
        {
            get
            {
                if (obj1 == null)
                { 
                     obj1 = new SomeObject(); 
                }
                return obj1;
            }
        }
        // same for the other objects
  
        [...]
    }
