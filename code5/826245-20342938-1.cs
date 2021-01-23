    public static void Main(string[] args)
    {
        Class1 class1 = new Class1();
        Console.WriteLine(class1.GetDisplayName(c => c.Title));
        Console.WriteLine(PropertyHelper.GetDisplayName<Class1>(c => c.Title));
    }
