    public static void Main()
    {
        double[][][] stats = new double[3][2][10];
        string[] players = new string[3];
        players[0] = "Tom Brady";
        players[1] = "Drew Brees";
        players[2] = "Peyton Manning";   
         
        for (int player = 0; player < 3; ++player)
        {
            Console.WriteLine("Enter stats for {0}", players[ player ]);
            for (int game = 0; game < 2; ++game)
            {
                Console.WriteLine("Game {0}", game + 1);
                stats[player][game] = inputstats();
            }
        }
    public static double[] inputstats()
    {
        //same code
    }
