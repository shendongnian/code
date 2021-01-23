     static void Main(string[] args)
        { 
            using (var 
    db = new SchoolEntities())
            {
                int currentScore = 0;
                int rank= 0;
                int savedRank;
            var query = db.ScoreSummaries
                .OrderByDescending(x => x.TotalScore).ToList();
            foreach (var item in query)
            {
          
          if(item.TotalScore == current score)
           {
            savedRank = savedRank
           }
           else
           {
             savedrank = rank;
            }
                rank+= 1;
                Console.WriteLine("{0},{1},{2}", item.TransactionID, item.TotalScore, savedrank);
                currentScore = item.totalScore;
                }
                Console.WriteLine("Pls press any key to exit");
                Console.ReadKey();
            }
        }
