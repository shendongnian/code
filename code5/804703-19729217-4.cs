    checked
    {
        Int64 a = 12345678912345;
        Console.WriteLine(a.ToString("X"));
        Console.WriteLine((a % ((long)uint.MaxValue + 1L)).ToString("X"));
        try
        {
            Console.WriteLine(((int)a).ToString("X")); // throws exception
        }
        catch (Exception e)
        {
            Console.WriteLine("It threw! " + e.Message);
        }
    }
    unchecked
    {
        Int64 a = 12345678912345;
        Console.WriteLine(a.ToString("X"));
        Console.WriteLine((a % (long)Math.Pow(2, 32)).ToString("X"));
        Console.WriteLine(((int)a).ToString("X"));
    }
