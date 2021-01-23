    public IEnumerable<Foo> SomeIteratorMethod(string mustNotBeNull)
    {
        if (mustNotBeNull == null)
        {
            throw ...
        }
        return SomeIteratorMethodImpl(mustNotBeNull);
    }
    private IEnumerable<Foo> SomeIteratorMethodImpl(string mustNotBeNull)
    {
        ... yield new Foo()...
    }
