    private EntitySet<AuthCategory> children = new EntitySet<AuthCategory>();
    [Association(Storage = "children", OtherKey = "ParentID")]
    public IEnumerable<AuthCategory> AuthCatChildren
    {
        get { return children; }
    }
    public IEnumerable<AuthCategory> Children
    {
        get { return (from x in AuthCatChildren select x).AsEnumerable(); }
    }
