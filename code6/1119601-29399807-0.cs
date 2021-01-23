     class Program
        {
            private static void Main(string[] args)
            {
                var h1 =  new Dictionary<string, int>();
                    h1.Add("One", 1);
                    h1.Add("Two", 2);
                var h2 = new Dictionary<string, int>();
                    h2.Add("One", 1);
                    h2.Add("Two", 2);
                    h2.Add("Three", 3);
                var unDict = h1.Union(h2).ToDictionary(d=>d.Key);
                SortedList sortedDictionary =
                    new SortedList(((IDictionary) unDict));
    
    
    
    
            }
        }
