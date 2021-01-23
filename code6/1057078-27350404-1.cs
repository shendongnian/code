            List<BowlingScore> scores = new List<BowlingScore>(5);
            for (int index = 0; index < 5; index++)
            {
                Console.WriteLine("Enter in a name and score: ");
                string line = Console.ReadLine();
                BowlingScore bowlingScore = new BowlingScore();
                bowlingScore.Name = line.Substring(0, line.IndexOf(' '));
                bowlingScore.Score = int.Parse(line.Substring(line.IndexOf(' ') + 1));
                scores.Add(bowlingScore);
            }
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
        static void LowScores(List<BowlingScore> scores)
        {
            int highScore = scores.ElementAt(scores.Count - 1).Score;
            for (int index = scores.Count - 1; index > 0; index--)
            {
                BowlingScore bowlingScore = scores.ElementAt(index);
                if (bowlingScore.Score == highScore)
                {
                    Console.WriteLine(string.Format("Low Score: {0} {1}", bowlingScore.Name, bowlingScore.Score));
                }
                else
                {
                    break;
                }
            }
        }
        static void HighScores(List<BowlingScore> scores)
        {
            int lowScore = scores.ElementAt(0).Score;
            for (int index = 0; index < scores.Count; index++)
            {
                BowlingScore bowlingScore = scores.ElementAt(index);
                if (bowlingScore.Score == lowScore)
                {
                    Console.WriteLine(string.Format("High Score: {0} {1}", bowlingScore.Name, bowlingScore.Score));
                }
                else
                {
                    break;
                }
            }
        }
