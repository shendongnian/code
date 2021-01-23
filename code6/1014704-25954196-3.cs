    public void DisplayLetter(char val)
    {
        Console.Write("Char: {0}", val);
        Console.Write("Decimal: {0}", (int)val);
        Console.Write("Hex: {0:X}", (int)val);
        Console.Write("Octal: {0}", Convert.ToString((int)val, 8));
        Console.Write("Binary: {0}", Convert.ToString((int)val, 2));
    }
