    class Foo<T>
    {
        public List<T> GenericList { get; set; }
    
        public Foo()
        {
            this.GenericList = new List<T>();
        }
    }
