    public void foobar(Foo f) 
    {
        dynamic df = (dynamic)f;
        int y;
        try
        {
           y = df.y;
        }
        catch (RuntimeBinderException)
        {
           // case when foo doesn't have a y
        }
    }
