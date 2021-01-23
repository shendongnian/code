    int Bowl; // Variable to hold number
    ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input
    // We check input for a Digit
    if (char.IsDigit(UserInput.KeyChar))
    {
         Bowl = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
    }
    else
    {
         Bowl = -1;  // Else we assign a default value
    }
