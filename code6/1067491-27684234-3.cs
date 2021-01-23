    public delegate string ToStringFunc();
    public static void Main(string[] args)
    {
        dynamic test = new ExpandoObject();
        test.ToString = new ToStringFunc(() =>
            {
                return "Test";
            });
        Console.WriteLine(test.ToString());
    }
