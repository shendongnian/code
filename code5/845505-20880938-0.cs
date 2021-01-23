    public ClassA
    {
        public event EventHandler SomeEvent = (s,e) => { };
        private ClassB classB = new ClassB();
        
        public ClassA()
        {
           classB.SomeEvent += (s,e) => SomeEvent(this, e);
        }    
    }
