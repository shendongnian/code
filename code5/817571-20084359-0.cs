    public void CallFoo(object x)
    {
        if (x is B)
        {
            a.Foo((B)x);
        }
        else
        {
            a.Foo(x);
        }
    }
