    static void Main(string[] args)
    {
        try
        {
             Foo();
        }
        catch (MyException ex)
        {
             Console.WriteLine(ex.Message)
        }
    }
    
    static void Foo()
    {
        throw new MyException()
    }
