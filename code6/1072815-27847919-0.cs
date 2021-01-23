    public static IEnumerable<int> generateNumber(int timesUserWantsToGuess)
    {
       Random rnd = new Random();
       for (int i = 0; i < timesUserWantsToGuess; i++)
        {
            int num = rnd.Next(1, 50);
            yield return num;
        }
    }
