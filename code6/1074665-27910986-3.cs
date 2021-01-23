    private readonly bool __backingFieldCanRead;
    public MyClassConstructor()
    {
        __backingFieldCanRead = true;
    }
    public override bool CanRead
    {
        get
        {
            return __backingFieldCanRead;
        }
    }
