    using System;
    using System.Linq;
    
    namespace experiment
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = "{101110111010001111}";
                string[] sequences = data.Split(new string[] {"111"}, StringSplitOptions.None);
                int validCounts = sequences.Count(i => i.Substring(0, 1) != "1");
                Console.WriteLine("Count of sequences: {0}", validCounts);
                // See the splited array
                foreach (string item in sequences) {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
        }
    }
