    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] {1, 3, 5, 7, 9, 11, 13};
            foreach (var num in numbers.TicTac())
            {
                Console.WriteLine(num);
            }
            Console.Read();
        }
    }
    static class Extensions
    {
        public static IEnumerable<T> TicTac<T>(this IEnumerable<T> source)
        {
            var count = source.Count();
            var leftIterator = source.GetEnumerator();
            var rightIterator = source.Reverse().GetEnumerator();
            int returned = 0;
            bool right = false;
            
            while (returned < count)
            {
                if (right)
                {
                    rightIterator.MoveNext();
                    yield return rightIterator.Current;
                }
                else
                {
                    leftIterator.MoveNext();
                    yield return leftIterator.Current;
                }
                returned++;
                right = !right;
            }
        }
    }
