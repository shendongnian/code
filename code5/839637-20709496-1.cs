    checked
    {
        byte b = byte.MaxValue;
        Console.WriteLine(b);               // b=255
        try
        {
            Console.WriteLine(++b);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);   // "Arithmetic operation resulted in an overflow." 
                                            // b = 255
        }
    }
