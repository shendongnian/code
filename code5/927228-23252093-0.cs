    public void DoSomething<T>(T input, Func<T, byte[]> f)
    {
        byte[] bytes = f(input);
        //handle bytes
    }
    DoSomething(true, BitConverter.GetBytes);
