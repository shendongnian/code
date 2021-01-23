    public void GuessTheHiddenDigits(List<int> list)
    {
    	GuessingGame playerGuess = new GuessingGame();
    	playerGuess.Guesses = new List<int>();
    	playerGuess.Guesses.AddRange(list);
    }
