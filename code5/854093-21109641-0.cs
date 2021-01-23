    public enum Animals
    {
        dog = 0,
        cat = 1,
        rat = 2
    }
    ...
    Animals answer;
    if (Enum.TryParse("CAT", true, out answer))
    {
        int value = (int) answer;
        Console.WriteLine(value);
    }
