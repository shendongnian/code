		Dictionary<string, int> playerGoals = new Dictionarty<string, int>()'
        int numberOfPlayers;
        Console.WriteLine("Enter the number of players:");
        numberOfPlayers = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Console.WriteLine("Enter a players name:");
            string playerName = Console.ReadLine();
            Console.WriteLine("Goals scored so far this season");
            int goalsScored = int.Parse(Console.ReadLine());
			
			playerGoals.Add(playerName, goalsScored);
        }
        double max = playerGoals.Values.Max();        
        double sum = playerGoals.Values.Sum();
        double average = sum / numberOfPlayers;
        Console.WriteLine("Top player is: {0} with {1} goals", player, max);
        Console.WriteLine("The average goals scored was:{0}",average);
        double min = playerGoals.Values.Min(); 
        Console.WriteLine("The lowest goals scored was: {0}", min);
        Console.ReadLine();
