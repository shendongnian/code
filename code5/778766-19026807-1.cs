    public void DoSomething<T>(T argument) // infer T from argument
    {
    }
    // so you can call
    DoSomething(new object()); // T is object
