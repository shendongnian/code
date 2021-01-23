    class Program
    {
        static void Main(string[] args)
        {
            foreach(var prime in new PrimeCollection())
            {
                Console.WriteLine(prime);
            }
            Console.Read();
        }
    }
    class PrimeCollection : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var ints = Enumerable.Range(2, Int32.MaxValue - 1);
            return ints.Where(x => !ints.TakeWhile(y => y < Math.Sqrt(x)).Any(y => x % y == 0)).GetEnumerator();
        }
    }
