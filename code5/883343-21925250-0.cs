    public dynamic Test()
    {
        return new {var1 = "", var2 = Guid.NewGuid()};
    }
    var output = Test();
    Console.WriteLine(output.var2);
