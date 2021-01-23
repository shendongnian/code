    public GuessResult MakeAGuess(int guess)
    {
        if (guess > target)
            return GuessResult.TooHigh;
        if (guess < target)
            return GuessResult.TooLow;
        return GuessResult.Correct;
    }
