    for (int x = 0; x < characters.Length; x++)
    {
        if (userInput == characters[x])
        {
            underscores[x] = userInput;
        }
    }
    Console.Write(underscores);
