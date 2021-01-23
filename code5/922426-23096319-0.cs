    public int ExecuteMain()
    {
        OtherClass.DoSomething(this); // just pass current instance using 'this'
    }
    public static void DoSomething(Main obj)
    {
        obj.SomeInt = 1;
    }
