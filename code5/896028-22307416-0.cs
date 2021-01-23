    int jurorCount = 0;
    bool validJurorCount = false;
    while (!validJurorCount)
    {
        Console.Write("Enter the number of jurors: ");
        validJurorCount = Int32.TryParse(Console.ReadLine(), out jurorCount) && jurorCount >= 0;
    }
    var votes = new List<int>();
    for (int i = 0; i < jurorCount; i++)
    {
        int vote = 0;
        bool validVote = false;
        while (!validVote)
        {
            Console.Write("Enter juror #{0}'s vote (1-10): ", i + 1);
            validVote = Int32.TryParse(Console.ReadLine(), out vote) && vote >= 1 && vote <= 10;
        }
        votes.Add(vote);
    }
