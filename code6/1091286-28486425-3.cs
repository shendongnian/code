    class Program
    {
        private static IEnumerable<string> SelectUnique(IEnumerable<string> list)
        {
            // iterate the list..
            foreach (var item1 in list)
                // you don't want to match the same item.
                if (!list.Where(item2 => item1 != item2)
                    // search for items where it start with the current item. (notice the ! before the list.Where)
                    .Any(item2 => item2.StartsWith(item1)))
                        yield return item1;
        }
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("Customers\\Order1\\Product1");
            list.Add("Customers\\Order2\\Product1");
            list.Add("Customers\\Order2\\Product1\\Price");
            list.Add("Customers\\Order1");
            list.Add("Customers\\Order3\\Price");
            var results = SelectUnique(list);
            foreach (var item in results)
                Console.WriteLine(item);
            Console.ReadKey();
        }
    }
