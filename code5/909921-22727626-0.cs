    class Program
    {
        static Random rnd=new Random();
        static void Main(string[] args)
        {
            var list=new SortedDictionary<double, int>();
            for (int i=1; i<100; i++)
            {
                list.Add(rnd.NextDouble(), i);
            }
            var random_int=list.Values.ToArray();
            // 45
            // 8
            // 72
            // ..
        }
    }
