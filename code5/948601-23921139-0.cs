    public Foo(long value)
    {
        m_value = value;
    }
    [Obsolete("Do not call this with ints")]
    public Foo(int value)
    {
        throw new NotImplementedException();
    }
