    public MyBaseClass()
    {
        var m = System.Reflection.MethodBase.GetCurrentMethod();
        Console.WriteLine(m.DeclaringType.Name);
    }
