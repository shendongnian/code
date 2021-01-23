    public static int Payout(IEnumerable<int> randoms, IEnumerable<int> guesses)
    {
        if (randoms.SequenceEqual(guesses))
            return 10000;
        IEnumerable<int> sortedRandoms = randoms.OrderBy(a => a);
        IEnumerable<int> sortedGuesses = guesses.OrderBy(a => a);
        if (sortedRandoms.SequenceEqual(sortedGuesses))
            return 1000;
        return 0;
    }
