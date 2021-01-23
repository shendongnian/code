    private static void Main()
    {
        . . .
                while (winner == null)
                {
                    round++;
                    AnnounceRound(round);
                    ShowScores("The current standings are:", players);
                    . . .
                }
                Console.Clear();
                Console.WriteLine("We have a winner! Congratulations, {0}!!", winner.Name);
                ShowScores("The final scores are:", players);
                . . .
    }
