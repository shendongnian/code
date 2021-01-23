            List<BowlingScore> scores = new List<BowlingScore>()
            {
                new BowlingScore() { Name = "Joe", Score = 278},
                new BowlingScore() { Name = "Pete", Score = 300},
                new BowlingScore() { Name = "Lisa", Score = 27},
                new BowlingScore() { Name = "Trevor", Score = 50},
                new BowlingScore() { Name = "Jim", Score = 78},
                new BowlingScore() { Name = "Bob", Score = 27},
                new BowlingScore() { Name = "Sally", Score = 50},
            };
            Console.WriteLine();
            Console.WriteLine("Here are the Scores:");
            scores.Sort();
            foreach (BowlingScore score in scores)
            {
                Console.WriteLine(score);
            }
            Console.WriteLine();
            HighScores(scores);
            Console.WriteLine();
            LowScores(scores);
            
            Console.WriteLine();
            Console.WriteLine(string.Format("Average score:{0}", scores.Average(f => f.Score)));
            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        static void HighScores(List<BowlingScore> scores)
        {
            int highScore = scores.ElementAt(scores.Count - 1).Score;
            for(int index = scores.Count -1; index > 0; index--)
            {
                BowlingScore bowlingScore = scores.ElementAt(index);
                if (bowlingScore.Score == highScore)
                {
                    Console.WriteLine(string.Format("High Score: {0} {1}", bowlingScore.Name, bowlingScore.Score));
                }
                else
                {
                    break;
                }
            }
        }
        static void LowScores(List<BowlingScore> scores)
        {
            int lowScore = scores.ElementAt(0).Score;
            for (int index = 0; index < scores.Count; index++)
            {
                BowlingScore bowlingScore = scores.ElementAt(index);
                if (bowlingScore.Score == lowScore)
                {
                    Console.WriteLine(string.Format("Low Score: {0} {1}", bowlingScore.Name, bowlingScore.Score));
                }
                else
                {
                    break;
                }
            }
        }
