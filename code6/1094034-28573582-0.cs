    public Main()
    {
        Foo foo = new Foo();
        foo.OnBarOneResponse += foo_OnBarOneResponse;
        foo.OnBarTwoResponse += foo_OnBarTwoResponse;
        foo.FetchBarOne();
    }
    
    void foo_OnBarOneResponse(String response)
    {
        // Called successfully.
        this.foo.FetchBarTwo();
    }
