    private Lazy<libDBDataContext> _DB = new Lazy<libDBDataContext>(
        () => new libDBDataContext()
    );
    public libDBDataContext DBContext
    {
        get { return _DB.Value; }
    }
