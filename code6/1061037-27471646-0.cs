    class SomeType
    {
        public string SomeState { get; set; }
        public SomeType()
        {
        }
    
        public SomeType(SomeType original)
        {
            this.SomeState = original.SomeState;
        }
    
    }
