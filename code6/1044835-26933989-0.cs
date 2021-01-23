    class Program
    {
        static void Main(string[] args)
        {
            String[] ContentArray = { "Id", "Name", "Username" };
            bool[] SelectionArray = { false, true, false };
            var selected = ContentArray.Zip(SelectionArray, (s, b) => 
              new Tuple<string, bool>(s, b))
                .Where(tuple => tuple.Item2)
                .Select(tuple => tuple.Item1)
                .ToList();
            foreach (var s in selected)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
