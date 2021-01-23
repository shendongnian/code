    class Program
        {
            static Random Random = new Random();
    
            static void Main(string[] args)
            {
                List<Flag> flags = new List<Flag>()
                                       {
                                           new Flag() {Name = "A"},
                                           new Flag() {Name = "B"},
                                           new Flag() {Name = "C"},
                                           new Flag() {Name = "D"}
                                       };
    
                Console.WriteLine(String.Join(",", flags.Select(f => f.Name)));
    
                IEnumerable<Flag> randomlyOrdered = flags.OrderBy(f => Random.Next());
                List<Flag> newListInDifferentOrder = new List<Flag>(randomlyOrdered);
    
                Console.WriteLine(String.Join(",", newListInDifferentOrder.Select(f=>f.Name)));
            }
    
            private class Flag
            {
                public String Name { get; set; }
            }
        }
