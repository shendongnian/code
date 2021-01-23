    class Program
    {
        static void Main(string[] args)
        {
            var delegates = new Dictionary<char, Action<char>>
            {
                {'e', c => { Console.WriteLine("Found an 'e'"); }},
                {'o', c => { Console.WriteLine("Found an 'o'"); }}
            };
            var s = "Hello World";
            var it = s.GetEnumerator();
            while (it.MoveNext())
            {
                if (delegates.ContainsKey(it.Current))
                    delegates[it.Current](it.Current);
            }
            Console.ReadKey();
        }
    }
