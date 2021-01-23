    public static Derived CreateDerived()
    {
       DisposeMe d = new DisposeMe();
       return new Derived(d);
    }
    private DisposeMe _d;
    private Derived(DisposeMe d) : base (d) 
    {
        _d = d;
    }
