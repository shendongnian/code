    [HttpPost]
    [ActionName("DefaultAction")]
    public HttpResponseMessage Post(MyClass obj)
    {
        // ...
    }
    // equivalent to:
    [HttpPost]
    public HttpResponseMessage DefaultAction(MyClass obj)
    {
        // ...
    }
