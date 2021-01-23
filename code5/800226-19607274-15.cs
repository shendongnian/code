    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Range>()
            {
                new Range(0, 1), 
                new Range(1, 4), 
                new Range(4, 8), 
                new Range(8, 14), 
                new Range(14, 20),
                new Range(22, 24),
            };
            // yes I know in this case they're already sorted...
            // but I want to stress the fact that you must sort the list
            list.Sort(new StartOnlyRangeComparer()); 
            var range10 = list.FindRangeContainingPoint(10); // returns (8,14)
            var range21 = list.FindRangeContainingPoint(21); // returns null
            var range20 = list.FindRangeContainingPoint(20); // returns null
            var range14 = list.FindRangeContainingPoint(14); // return (14,20)
       }
    }
