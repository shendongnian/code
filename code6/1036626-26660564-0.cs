    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new List<int> {1, 3, 5};
            var t2 = new List<int> {1, 51};
            var s = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            Console.WriteLine(s.Contains(t1));
            Console.WriteLine(s.Contains(t2));
        }
    }
    public static class Extensions
    {
        public static bool Contains(this List<int> source, List<int> target)
        {
            return !target.Except(source).Any();
        }
    }
