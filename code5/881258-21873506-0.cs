    class MyDisposableObject : IDisposable { /*...*/ }
    public MyDisposableObject MakeMeAnObject() { return new MyDisposableObject(); }
    public void Main()
    {
        using(var o = MakeMeAnObject())
        {
            o.Foo = 1;
            o.Bar = 2;
            o.FooBar();
        }
    }
