    public class HangCSharp
    {
    string[] words = new string[5] { "ARRAY", "OBJECT", "CLASS", "LOOP", "HUMBER" };
    List<char> guesses;
    Random random = new Random();
    string word = "";
    string current = "";
    int loss = 0;
    readonly int maxGuess = 6;
    int highScrore = 0;
    
    public void Run()
    {
        word = words[random.Next(0, words.Length)];
        current = new string('-', word.Length);
        loss = 0;
        guesses = new List<char>();
        while (loss < maxGuess)
        {
            Console.Clear();
            writeHeader();
            writeLoss();
            writeCurrent();
            var guess = Console.ReadKey().KeyChar.ToString().ToUpper()[0];
            while (!char.IsLetterOrDigit(guess))
            {
    
                Console.WriteLine("\nInvalid Guess.. Please enter a valid alpha numeric character.");
                Console.Write(":");
                guess = Console.ReadKey().KeyChar;
            }
            while (guesses.Contains(guess))
            {
                Console.WriteLine("\nYou have already guessed {0}. Please try again.", guess);
                Console.Write(":");
                guess = Console.ReadKey().KeyChar;
            }
    
            guesses.Add(guess);
            if (!isGuessCorrect(guess))
                loss++;
            else if (word == current)
                break;
        }
        Console.Clear();
        writeHeader();
        writeLoss();
        if (loss >= maxGuess)
            writeYouLoose();
        else
            doYouWin();
        Console.Write("Play again [Y\\N]?");
    
        while (true)
        {
            var cmd = (Console.ReadLine() ?? "").ToUpper()[0];
            if (cmd != 'Y' && cmd != 'N')
            {
                Console.WriteLine("Invalid Command. Type Y to start again or N to exit.");
                continue;
            }
            else if (cmd == 'Y')
                Run();
            break;
        }
    }
    
    bool isGuessCorrect(char guess)
    {
        bool isGood = word.IndexOf(guess) > -1;
        List<char> newWord = new List<char>();
        for (int i = 0; i < word.Length; i++)
        {
            if (guess == word[i])
                newWord.Add(guess);
            else
                newWord.Add(current[i]);
        }
        current = string.Join("", newWord);
        return isGood;
    }
    
    void writeCurrent()
    {
        Console.WriteLine("Enter a key below to guess the word.\nHint: {0}", current);
        if (guesses.Count > 0)
            Console.Write("Already guessed: {0}\n", string.Join(", ", this.guesses));
        Console.Write(":");
    }
    
    void writeHeader()
    {
        Console.WriteLine("Hang-CSharp... v1.0\n\n");
        if (highScrore > 0)
            Console.WriteLine("High Score:{0}\n\n", highScrore);
    }
    
    void writeYouLoose()
    {
        Console.WriteLine("\nSorry you have lost... The word was {0}.", word);
    }
    
    void doYouWin()
    {
        Console.WriteLine("Congratulations you guessed the word {0}.", word);
    
        int score = maxGuess - loss;
        if (score > highScrore)
        {
            highScrore = score;
            Console.WriteLine("You beat your high score.. New High Score:{0}", score);
        }
        else
            Console.WriteLine("Your score:{0}\nHigh Score:{1}", score, highScrore);
                
    }
    
    void writeLoss()
    {
        switch (loss)
        {
            case 1:
                Console.WriteLine(" C");
                break;
            case 2:
                Console.WriteLine(" C{0} #", Environment.NewLine);
                break;
            case 3:
                Console.WriteLine(" C\n/#");
                break;
            case 4:
                Console.WriteLine(" C\n/#\\");
                break;
            case 5:
                Console.WriteLine(" C\n/#\\\n/");
                break;
            case 6:
                Console.WriteLine(" C\n/#\\\n/ \\");
                break;
        }
        Console.WriteLine("\n\nLives Remaining {0}.\n", maxGuess - loss);
    }
    }
