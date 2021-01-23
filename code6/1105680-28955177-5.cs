    int Bowl; // Variable to hold number
    var UserInput = Console.ReadKey(); // get user input
    
    int Bowl; // Variable to hold number
    
    // We should check char for a Digit, so that we will not get exceptions from Parse method
    if (char.IsDigit(UserInput.KeyChar))
    {
        Bowl = int.Parse(UserInput.KeyChar.ToString());
        Console.WriteLine("\nUser Inserted : {0}",Bowl); // Say what user inserted 
    }
    else
    {
         Bowl = -1;  // Else we assign a default value
         Console.WriteLine("\nUser didn't insert a Number"); // Say it wasn't a number
    }
    
    if (Bowl == 5)
    {
        Console.WriteLine("OUT!!!!");
    }
    else
    {
        GenerateResult();
    }
