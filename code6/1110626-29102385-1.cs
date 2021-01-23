    private int foo
    public string Foo
    {
        get 
        { 
            return foo.ToString();
        }
        set
        {
            foo = Int32.Parse(value);
        }
    }
