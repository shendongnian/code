    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Rating = System.Collections.Generic.Dictionary<string, //rating
                                                         System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair<int, int>, //age range min-max
                                                                                                 System.Collections.Generic.KeyValuePair<int, int>>>; //score range min-max
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var lookup = new Rating();
                //build the thing doing only a few for now
                //15-19 score 60+
                lookup.Add("EXCELLENT", new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(new KeyValuePair<int, int>(15, 19), new KeyValuePair<int, int>(60, int.MaxValue)));
                //15-19 score 45-59
                lookup.Add("GOOD", new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(new KeyValuePair<int, int>(15, 19), new KeyValuePair<int, int>(45, 59)));
                //40-49 score <25
                lookup.Add("POOR", new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(new KeyValuePair<int, int>(40, 49), new KeyValuePair<int, int>(int.MinValue, 24)));
                process(lookup, 16, 50);
                process(lookup, 16, 70);
                process(lookup, 45, 20);
                process(lookup, 10, 50);
                Console.Read();
            }
            static void process(Rating rate, int age, int score)
            {
                var rating = rate.Where(x => x.Value.Key.Key <= age && x.Value.Key.Value >= age &&
                                            x.Value.Value.Key <= score && x.Value.Value.Value >= score).FirstOrDefault();
                Console.WriteLine("For age {0} and score {1} you have this rating {2}", age, score, string.IsNullOrEmpty(rating.Key) ? "Unrated" : rating.ToString());
            }
        }
    }
