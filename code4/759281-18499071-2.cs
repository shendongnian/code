    class Program
    {
        public IEnumerator<int> GetEnumerator()  // IEnumerable<int> works too.
        {
            for (int i = 0; i < 5; i++)     
                yield return i;     
        }
        static void Main(string[] args)
        {
            var p = new Program();
            foreach (int x in p)
            {
                Console.WriteLine(x);
            }
        }
    }
