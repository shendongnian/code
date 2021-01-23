    static void Main(string[] args)
    {  
    	...
    	
    	for (int i = 0; i < 3; i++) //this loop is for the 3 rounds
    	{
    		foreach (var player in players) //this one is for all the players
    		{
    			for (int j = 0; j < 3; j++) //and this loop is for the 3 scores in each round
    			{
    				Console.WriteLine("Player {0}", player.Name); //output the player name
    				
    				List<int> roundScores;
    				//this is not the best way to do it, but it's easier to understand
    				if (j=0) roundScores = player.round1Scores;
    				else if (j=1) roundScores = player.round2Scores;
    				else if (j=2) roundScores = player.round3Scores;
    				
    				Console.WriteLine("Enter points1 for round {}", i);
    				roundScores.Add(Convert.ToInt32(Console.ReadLine()));
    				Console.WriteLine("Enter points2 for round {}", i);
    				roundScores.Add(Convert.ToInt32(Console.ReadLine()));
    				Console.WriteLine("Enter points3 for round {}", i);
    				roundScores.Add(Convert.ToInt32(Console.ReadLine()));
    			}
    		}
    	}
    	printAllPlayers(players);
    }
    
    static void printAllPlayers(List<Player> players)
    {
    	Console.WriteLine("Printing {0} players ...", players.Count);
    	foreach (Player player in players)
    	{
    		player.calcTotalScore(); //calculate the total score for this player
    		Console.WriteLine("Player: {0} \nScore: {1}", player.Name, player.Score);
    	}
    }
    
    
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<int> round1Scores { get; set; } // I used a List<int> here but you can choose to use an array int[] too
        public List<int> round2Scores { get; set; }
        public List<int> round3Scores { get; set; }
    
        public void calcTotalScore()
        {
    		Score = 0; //initialize the total score.
    		
    		for (int i = 0; i < 3; i++)
    		{
    			Score += round1Scores[i];
    			Score += round2Scores[i];
    			Score += round3Scores[i];
    		}
        }
    }
