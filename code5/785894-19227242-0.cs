    public static MyObject ConvertFromComObject(dynamic comObject)
    {
        return comObject.Object;
    }
    // or, if that doesn't work:
    public static MyObject ConvertFromComObject(dynamic comObject)
    {
        return new MyObject { MyProperty = comObject.Object.MyProperty };
    }
    // or maybe
    public static MyObject ConvertFromComObject(dynamic comObject)
    {
        return new MyObject { MyProperty = comObject.MyProperty };
    }
