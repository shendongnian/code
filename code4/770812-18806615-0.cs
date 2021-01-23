    public void ClassGet(string MyClassName,string blabla)
    {
        object instance = Activator.Create(MyClassName);
    }
    // Call it like:
    Gold g = new Gold();
    g.ClassGet("MyClass", "blabla");
