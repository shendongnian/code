    public void Ref_Test(ref int x)
    {
        var y = x; // ok
        x = 10;
    }
    // x is treated as an unitialized variable
    public void Out_Test(out int x)
    {
        var y = x; // not ok (will not compile)
    }
    public void Out_Test2(out int x)
    {
        x = 10;
        var y = x; // ok because x is initialized in the line above
    }
