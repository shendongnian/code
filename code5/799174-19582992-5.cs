    public static void OptionalParamMethod(bool input, string input2 = null)
    {
    }
    public static void Main(string[] args)
    {
        OptionalParamMethod(true);
        OptionalParamMethod(false, "hello");
    }
