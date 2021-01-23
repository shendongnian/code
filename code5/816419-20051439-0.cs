    public static Foo FromBarAndBaz(string bar, List<int> baz = null)
    {
        return new Foo(bar, baz);
    }
    public static Foo FromQwop(string qwop)
    {
        return new Foo(qwop);
    }
