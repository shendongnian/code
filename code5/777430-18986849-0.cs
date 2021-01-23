    static void Main(string[] args)
    {
        try
        {
             throw new MyException();
        }
        catch (DivideByZeroException ex)
        {
             Console.WriteLine("Exception caught");
        }
    }
