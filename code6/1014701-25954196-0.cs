    public char PromptforLetter(string prompt)
    {
        Console.Write(prompt + " "); // This prints out the prompt with a space, and no
                                     // following line break
        // Now you have a choice. Should you take the first key that is pressed, or 
        // should the user have to press enter?
        // Option 1:
        char ret = Console.ReadKey().KeyChar;
        Console.WriteLine(); // Not necessary, but it improves user experience
        return ret;
        // Option 2:
        return Console.ReadLine()[0]; // take the first indexed character from the
                                      // string entered by the user. Strings have 
                                      // integer-indexers, so you can access single them
                                      // characters in kind of like you would if they were
                                      // a string array.
    }
