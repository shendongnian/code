    char[] guess = underscores.ToCharArray();
    for (int x = 0; x < characters.Length; x++)
    {
        if (userInput == characters[x])
        {
            guess[x] = userInput;
        }
    }
    Console.Write(guess);
