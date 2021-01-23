     static void Main(string[] args)
        { 
            using (var 
    db = new SchoolEntities())
            {
                double currentScore = 0;
                int rank= 0;
                int savedRank;
            var query = db.ScoreSummaries
                .OrderByDescending(x => x.TotalScore).ToList();
            foreach (var item in query)
            {
          
          rank+= 1;
          if(item.TotalScore == current score)
           {
            savedRank = savedRank
           }
           else
           {
             savedrank = rank;
            }
                
                Console.WriteLine("{0},{1},{2}", item.TransactionID, item.TotalScore, savedrank);
                currentScore = item.totalScore;
                }
                Console.WriteLine("Pls press any key to exit");
                Console.ReadKey();
            }
        }
