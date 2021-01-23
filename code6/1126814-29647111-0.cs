    class Program
    {
        static void Main(string[] args)
        {
            var oldList = new List<string> { "aaa", "bbb", "ccc", "ddd", "eee", "fff", "ggg", "hhh", "iii" };
            var newList = new List<string> { "aaa", "bbb", "ccc", "ddd" };//True
            var newList2 = new List<string> { "bbb", "ccc", "ddd" };//True
            var newList3 = new List<string> { "bbb", "ddd", "fff" };//True
            var newList4 = new List<string> { "bbb", "ccc", "aaa", "ddd", "ggg", "fff" };//False
            var newList5 = new List<string> { "bbb", "ccc", "aaa" };//False
            Console.WriteLine("Expected: true, Actual: " + IsCorrectOrder(oldList, newList));
            Console.WriteLine("Expected: true, Actual: " + IsCorrectOrder(oldList, newList2));
            Console.WriteLine("Expected: true, Actual: " + IsCorrectOrder(oldList, newList3));
            Console.WriteLine("Expected: false, Actual: " + IsCorrectOrder(oldList, newList4));
            Console.WriteLine("Expected: false, Actual: " + IsCorrectOrder(oldList, newList5));
            Console.ReadKey(true);
        }
        
        public static bool IsCorrectOrder(IList<string> orderedSequence, IList<string> testedSequence)
        {
            var lastFoundIndex = 0;
            for (var i = 0; i < testedSequence.Count; i++)
            {
                var testedElement = testedSequence[i];
                var testedFound = false;
                // finding first matching item in ordered sequence
                for (var j = lastFoundIndex; j < orderedSequence.Count; j++)
                {
                    var orderedElement = orderedSequence[j];
                    if (orderedElement == testedElement)
                    {
                        lastFoundIndex = j;
                        testedFound = true;
                        break;
                    }
                }
                if (testedFound)
                    continue;
                // if there is no such element, then the order is not correct
                return false;
            }
            return true;
        }
    }
