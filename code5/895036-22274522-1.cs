    public void Create(object propertyValues)
    {
        // dummy value for the right type
        var o = new { Code = 0, ProductName = "P", };
        o = Cast(o, propertyValues);
        Console.WriteLine(o.ProductName);
    }
    public void CallMethod()
    {
        Create(new
        {
            Code = 100,
            ProductName = "P1",
        });
    }
    private static T Cast<T>(T type, Object value)
    {
        return (T)value;
    }
