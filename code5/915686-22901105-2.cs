    static void InputData(List<string> playerNames, List<int> playerScore) {
        // The caller is assumed to have assigned non-null lists to the two arguments
        int i = 0;
        while (true) {
            Console.WriteLine("Enter the name of the player...Enter \"Q to exit...");
            string playerName = Console.ReadLine();
            if (playerName == "Q" || playerName == "q") break;
            playerNames.Add(playerName);
            ... // The rest of your loop goes here
        }
    }
