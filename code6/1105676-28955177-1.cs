    ConsoleKeyInfo UserInput = Console.ReadKey();
    
    int Bowl = -1; // Some value that's not equal to 5 : Kind of the default
    
    // We should check char for a Digit, so that we will not get exceptions from Parse method
    if (char.IsDigit(UserInput.KeyChar))
    {
        Bowl = int.Parse(UserInput.KeyChar.ToString());
    }
    
    Console.WriteLine("\nUser Inserted : {0}",Bowl);
    
    if (Bowl == 5)
    {
        Console.WriteLine("OUT!!!!");
    }
    else
    {
        GenerateResult();
    }
