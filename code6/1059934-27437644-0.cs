    private static readonly string[] words = { "Easy", "Medium", "Hard" };
    public static IReadOnlyCollection<string> Words
    {
        get
        {
            return words.ToList().AsReadOnly();
        }
    }
