    public static void AnnounceRound(int roundNumber)
    {
        Console.Clear();
        var announcement = string.Format("Beginning Round #{0}", roundNumber);
        Console.WriteLine(announcement);
        // The next line writes out a list of dashes that is the 
        // exact length of the announcement (like an underline)
        Console.WriteLine(new string('-', announcement.Length));
    }
