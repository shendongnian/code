    class Program
    {
        private static IList<string> list1 = new List<string>() { "v1001", "v1002", "v1003", "v1004" };
        private static IList<string> list2 = new List<string>(list1);
        static void Main(string[] args)
        {
            list1.Remove("v1001");
            print(list1);
            print(list2);
        }
        private static void print(IList<string> list)
        {
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
        }
    }
