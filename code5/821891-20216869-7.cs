    static void Main(string[] args)
            {
                var weasleys = new List<string> { "Bill", "Charlie", "Percy", 
                           "Fred", "George", "Ron", "Ginny" };
                var sortLength = new SortStringLength();
                weasleys.Sort(sortLength);
    
                foreach (var weasley in weasleys)
                {
                    Console.WriteLine(weasley);
                }
    
                Console.ReadLine();
            }
