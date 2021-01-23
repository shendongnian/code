    public static void myGeneralMethod(int ID, Action<string> method )
    {
        string myString = grabString(ID);
        method(myString);
        Console.WriteLine(myString);
    }
    public static void SomeStuffForAdd(string myString)
    {
    }
    public static void SomeOtherStuffRemove(string myString)
    {
    }
