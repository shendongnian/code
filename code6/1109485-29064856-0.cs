    private static void Main()
    {
        var cardBag = new List<int>();
        var drawnCards = new List<int>();
        // Add 15 numbers to the cardBag
        for (int i = 1; i <= 15; i++)
        {
            cardBag.Add(i);
        }
        // Draw 3 cards at random
        var rnd = new Random();
        while (drawnCards.Count < 3)
        {
            var candidateCard = cardBag[rnd.Next(15)];
            // In this implementation, we only add unique cards
            if (!drawnCards.Contains(candidateCard))
                drawnCards.Add(candidateCard);
        }
            
        // This will be set to true if the sum of the numbers is evenly divisible by 3
        bool numbersAreDivisibleByThree = drawnCards.Sum() % 3 == 0;
        // Output results to console
        Console.WriteLine("The three random cards drawn from the deck are: {0}", 
            string.Join(", ", drawnCards));
        Console.WriteLine("The sum of the cards is: {0}", drawnCards.Sum());
        Console.WriteLine("Is the sum of the cards evenly divisible by three? {0}.", 
            numbersAreDivisibleByThree);
    }
