    public static void Test(MyStruct s)
    {
        s.Prop1 = 2;
        s.Prop2 = 3;
    }
    public static void Test2(ref MyStruct s)
    {
        s.Prop1 = 2;
        s.Prop2 = 3;
    }
