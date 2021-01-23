    class XYZ{
    private readonly int x;
    public XYZ()
    {
    x = 10; //works
    }
    
    public void SomeMethod()
    {
     x = 100; //does not work since it is readonly
    }
    }
