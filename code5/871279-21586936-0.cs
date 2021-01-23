    String s=method(samples);
    int i;
    try
    {
         i=s.ToDecimal();
    }
    catch (FormatException e)
    {
        Console.WriteLine("Input string is not a sequence of digits.");
    }
    catch (OverflowException e)
    {
        Console.WriteLine("The number cannot fit in an Int32.");
    }  
