    private int foo
    public string Foo
    {
        get 
        { 
            return foo.ToString();
        }
        set
        {
            foo = int.Parse(value);
        }
    }
