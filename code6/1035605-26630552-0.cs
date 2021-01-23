    public interface IBar
    {
        int Y { get; }
    }
    
    public Bar : Foo, IBar { ... }
    
    public void foobar(IBar f) {
        int y = f.Y;
    }
