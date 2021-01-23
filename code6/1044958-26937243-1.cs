    interface IFoo
    {
        string Foo { get; }
    }
    
    
    abstract class Bar : IFoo
    {
        public string Foo { get; protected set; }
    }
