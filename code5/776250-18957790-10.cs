    struct SomeStruct 
    {
        public int Value;
        public void DoSomething()
        {
            Console.WriteLine(this.Value);
        }
    }
    
    SomeStruct c; // this is placed on stack
    c.DoSomething();
    
