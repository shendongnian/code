    const int minimumVote = 1;
    const int maximumVote = 10;
    int jurorCount;
    do
    {
        Console.Write("Enter the number of jurors: ");
    } while (!Int32.TryParse(Console.ReadLine(), out jurorCount) || jurorCount < 0);
    var votes = new List<int>();
    for (int i = 0; i < jurorCount; i++)
    {
        int vote;
        do
        {
            Console.Write("Enter juror #{0}'s vote ({1}-{2}): ", i + 1, minimumVote, maximumVote);
        } while (!Int32.TryParse(Console.ReadLine(), out vote) || vote < minimumVote || vote > maximumVote);
        votes.Add(vote);
    }
