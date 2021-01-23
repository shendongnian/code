    using System;
    using System.Linq;
    namespace HighScore
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] scores = {
                    "78",
                    "98",
                    "88",
                    "77",
                    "Bad score",
                    "124",
                    "3",
                    "678",
                    "4",
                    "123",
                    "456",       
                };
                //scores = File.ReadAllLines(@"C:\score.txt");
                int maxScore = scores.Select(line => {
                    int score = 0;
                    int.TryParse(line, out score);
                    return score;
                }).Max();
                Console.WriteLine("Maximum score is {0}", maxScore);
                Console.ReadKey();
            }
        }
    }
