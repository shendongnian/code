    public static void ExampleMethod(bool? optionalBool = null)
    {
        Console.WriteLine(optionalBool == null ? "Value not passed" : "Value passed");
    }
    public static void Main()
    {
        ExampleMethod();
        ExampleMethod(true);
        ExampleMethod(false);
    }
