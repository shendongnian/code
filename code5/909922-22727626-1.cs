    class Program
    {
        static Random rnd=new Random();
        static void Main(string[] args)
        {
            var list=new SortedDictionary<double, int>();
            // Fill list
            for (int i=1; i<=99; i++)
            {
                list.Add(rnd.NextDouble(), i);
            }
            // List Automatically random
            var random_int=list.Values.ToArray();
            // random_int = {45, 7, 72, .. }
        }
    }
