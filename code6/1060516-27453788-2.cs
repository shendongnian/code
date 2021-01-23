    private Task<Foo> RunExecute(bool async = false)
    {
        Foo outputFoo;
        if(async)
        {
            return makeFooAsync();
        }
        else
        {
            return Task.FromResult(makeFoo());
        }
    }
