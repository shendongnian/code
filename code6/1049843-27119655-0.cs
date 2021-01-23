    static int GetEdits(string answer, string guess)
    {
        guess = guess.ToLower();
        answer = answer.ToLower();
    
        int[,] d = new int[answer.Length + 1, guess.Length + 1];
        for (int i = 0; i <= answer.Length; i++)
            d[i, 0] = i;
        for (int j = 0; j <= guess.Length; j++)
            d[0, j] = j;
        for (int j = 1; j <= guess.Length; j++)
            for (int i = 1; i <= answer.Length; i++)
                if (answer[i - 1] == guess[j - 1])
                    d[i, j] = d[i - 1, j - 1];  //no operation
                else
                    d[i, j] = Math.Min(Math.Min(
                        d[i - 1, j] + 1,    //a deletion
    
                        d[i, j - 1] + 1),   //an insertion
    
                        d[i - 1, j - 1] + 1 //a substitution
    
                    );
        return d[answer.Length, guess.Length];
    }
    
    static void Main(string[] args)
    {
        const string text = @"lorem ipsum is simply dummy text of the printing and typesetting industry. Loren Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing LorenIpsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of LoremIpsum.";
    
        var findWords = new string[]
        {
            "Lorem Ipsum",
            "Centuries",
            "Electronic"
        };
    
        const int MaxErrors = 2;
    
        // Tokenize text
        var tokens = text.Split(' ', ',' , '.');
    
        for (int i = 0; i < tokens.Length; i++)
        {
            if( tokens[i] != String.Empty)
            {
                foreach (var findWord in findWords)
                {
                    if (GetEdits(findWord, tokens[i]) <= MaxErrors)
                    {
                        Console.WriteLine(tokens[i]);
                        break;
                    }
                    // Join with the next word and check again.
                    else if(findWord.Contains(' ') && i + 1 < tokens.Length)
                    {
                        string token = tokens[i] + " " + tokens[i + 1];
                        if (GetEdits(findWord, token) <= MaxErrors)
                        {
                            Console.WriteLine(token);
                            i++;
                            break;
                        }
                    }
                }
            }
        }
    }
