    interface IFoo
    {
        void M();
    }
    interface IBar
    {
        void M();
    }
    class C : IFoo, IBar 
    { 
        public void M() { } 
    }
