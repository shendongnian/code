    string gameWord = "Random"; 
    char guessedLetter = char.Parse(Console.ReadLine());
    for (int i=0; i < gameWord.length; i++) {
        if (gameWord[i] == guessedLetter)
            Console.WriteLine("Letter was found!"); 
    }
