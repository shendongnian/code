    string input = Console.ReadLine();
    // create an array of keywords
    string[] choices = new string[] { "first", "second", "third" };
    // get the index of the choice
    int choice = -1;
    for (int i = 0; i < choices.Length; i++)
    {
        // match case insensitive
        if (string.Equals(choices[i], input, StringComparison.OrdinalIgnoreCase))
        {
            choice = i; // set the index if we found a match
            break; // don't look any further
        }
    }
    // check for invalid input
    if (choice == -1)
    {
       // invalid input;
    }
