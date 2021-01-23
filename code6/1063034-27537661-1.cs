    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        struct AgeScore
        {
            public MinMax Age;
            public MinMax Score;
            public AgeScore(MinMax Age, MinMax Score)
            {
                this.Age = Age;
                this.Score = Score;
            }
            public override string ToString()
            {
                return string.Format("Age {0} - Score {1}", Age, Score);
            }
        }
        struct MinMax
        {
            int min;
            int max;
            public bool Between(int num)
            {
                return num >= min && num <= max;
            }
            public MinMax(int min, int max)
            {
                this.min = min;
                this.max = max;
            }
            public override string ToString()
            {
                return string.Format("Range: {0}-{1}", min, max);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var lookup = new Dictionary<string, AgeScore>();
                BuildRating(lookup);
                process(lookup, 16, 50);
                process(lookup, 16, 70);
                process(lookup, 45, 20);
                process(lookup, 10, 50);
                Console.Read();
            }
            static void BuildRating(Dictionary<string, AgeScore> rating)
            {
                //ONLY DOING A FEW FOR DEMO PURPOSE
                //age 15-19 score 60+
                rating.Add("EXCELLENT", new AgeScore(new MinMax(15, 19), new MinMax(60, int.MaxValue)));
                //age 15-19 score 45-59
                rating.Add("GOOD", new AgeScore(new MinMax(15, 19), new MinMax(45, 59)));
                //age 40-49 score <25
                rating.Add("POOR", new AgeScore(new MinMax(40, 49), new MinMax(int.MinValue, 24)));
            }
            static void process(Dictionary<string, AgeScore> rate, int age, int score)
            {
                var rating = rate.Where(x => x.Value.Age.Between(age) &&
                                             x.Value.Score.Between(score)).FirstOrDefault();
                Console.WriteLine("For age {0} and score {1} you have this rating is {2}\n", age, score, string.IsNullOrEmpty(rating.Key) ? "Unrated" : rating.ToString());
            }
        }
    }
