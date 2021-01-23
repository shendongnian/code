    public static int Foo(bool b)
    {
        switch (b)
        {
            default:
                goto default;
        }
    }
