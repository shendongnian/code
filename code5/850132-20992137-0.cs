    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            a.Add(2);
            a = add(a, 3);
            b = add(a, 4);
            b.Add(5);
            a.Add(6);
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in b)
            {
                Console.WriteLine(item);
            }
        }
        static List<int> add(List<int> l, int x)
        {
            List<int> result = new List<int>(l);
            result.Add(x);
            return result;
        }
    }
