    public static void Main(string[] args)
    {
        OptionalParamMethod(true, null);
        OptionalParamMethod(false, "hello");
        OverloadParamMethod(true);
        OverloadParamMethod(false, "hello");
    }
    public static void OptionalParamMethod(bool input, [Optional, DefaultParameterValue(null)] string input2)
    {
        Console.WriteLine("OptionalParamMethod");
    }
    public static void OverloadParamMethod(bool input)
    {
        OverloadParamMethod(input, null);
    }
    public static void OverloadParamMethod(bool input, string input2)
    {
        Console.WriteLine("OverloadParamMethod");
    }
 
