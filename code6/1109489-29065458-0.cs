    //Declare the function "interface"
    delegate string UppercaseDelegate(string input);
    //Declare the function to be passed
    static string UppercaseAll(string input)
    {
	return input.ToUpper();
    }
    //Declare the methode the accepts the delegate
    static void WriteOutput(string input, UppercaseDelegate del)
    {
        Console.WriteLine("Before: {0}", input);
        Console.WriteLine("After: {0}", del(input));
    }
    static void Main()
    {
	WriteOutput("test sentence", new UppercaseDelegate(UppercaseAll));
    }
