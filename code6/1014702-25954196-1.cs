    public void DisplayLetter(char val)
    {
        Console.Write(val); // just write it to the console
        // Or if you want to be fancy about it, you could also say this, which formats it.
        Console.Write("The key pressed was: {0}", val);
    }
